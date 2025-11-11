using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Map.Models;
using Map.Graph;
using System.Diagnostics;

namespace Map
{
    public partial class Form1 : Form
    {
        private Dictionary<int, List<Edge>> graph;
        private Node[] nodes;
        private List<int> lastPath;
        private List<(double x1, double y1, double x2, double y2, double R)> loadedQueries;

        public Form1()
        {
            InitializeComponent();

            graphPanel.Paint += GraphPanel_Paint;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void RunGraphQueries()
        {
            graph = null;
            nodes = null;
            lastPath = new List<int>();
            loadedQueries = new List<(double, double, double, double, double)>();
            comboBox1.Items.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();


            Stopwatch totalStopwatch = new Stopwatch();
            totalStopwatch.Start();

            string map_filepath = txtMapPath.Text;
            string query_filepath = txtQueryPath.Text;
            string test_filepath = txtTextPath.Text;
            string output_filepath = txtOutputPath.Text;

            if (string.IsNullOrWhiteSpace(map_filepath) ||
                string.IsNullOrWhiteSpace(query_filepath) ||
                string.IsNullOrWhiteSpace(test_filepath) ||
                string.IsNullOrWhiteSpace(output_filepath) ||
                !File.Exists(map_filepath) ||
                !File.Exists(query_filepath) ||
                !File.Exists(test_filepath))
            {
                MessageBox.Show("Please provide valid and existing file paths for Map, Query, Test, and Output.");
                return;
            }

            string[] queries = File.ReadAllLines(query_filepath);
            string[] mapLines = File.ReadAllLines(map_filepath);

            (graph, nodes) = Map.Graph.Graph.ConstructGraph(mapLines);

            int qIndex = 0;
            int qCount = int.Parse(queries[qIndex++]);

            loadedQueries = new List<(double, double, double, double, double)>();
            comboBox1.Items.Clear();

            test_cases test = new test_cases(test_filepath);

            bool allTestsPassed = true;

            Stopwatch queryStopwatch = new Stopwatch();
            queryStopwatch.Start();

            using (StreamWriter writer = new StreamWriter(output_filepath))
            {
                for (int i = 0; i < qCount; i++)
                {
                    string[] parts = queries[qIndex++].Split();
                    double x1 = double.Parse(parts[0]);
                    double y1 = double.Parse(parts[1]);
                    double x2 = double.Parse(parts[2]);
                    double y2 = double.Parse(parts[3]);
                    double R = double.Parse(parts[4]);

                    loadedQueries.Add((x1, y1, x2, y2, R));
                    comboBox1.Items.Add($"Query {i + 1}");

                    (List<int> path, double totalTime, double vehicleDistance, double walkingDistance) =
                    Map.Graph.Dijkstra.FindShortestPath(graph, nodes, x1, y1, x2, y2, R);

                    writer.WriteLine(string.Join(" ", path));
                    writer.WriteLine($"{totalTime:F2} mins");
                    writer.WriteLine($"{(vehicleDistance + walkingDistance):F2} km");
                    writer.WriteLine($"{walkingDistance:F2} km");
                    writer.WriteLine($"{vehicleDistance:F2} km");
                    writer.WriteLine();

                    bool testResult = test.testcasesfun(path, totalTime, vehicleDistance, walkingDistance);
                    if (!testResult)
                    {
                        allTestsPassed = false;
                    }
                }

                queryStopwatch.Stop();
                writer.WriteLine($"{queryStopwatch.ElapsedMilliseconds} ms");
                writer.WriteLine();
                totalStopwatch.Stop();
                writer.WriteLine($"{totalStopwatch.ElapsedMilliseconds} ms");
            }



            if (allTestsPassed)
            {
                MessageBox.Show("Graph queries finished. All test cases passed. Good!");
            }
            else
            {
                MessageBox.Show("Graph queries finished, but some test cases failed. Please check the output.");
            }
        }

        private PointF Transformtoscreen(double x, double y, double minX, double minY, double scale, int panelHeight, int padding)
        {
            float tx = (float)((x - minX) * scale + padding);
            float ty = (float)(panelHeight + padding - (y - minY) * scale);
            return new PointF(tx, ty);
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (graph == null || nodes == null || nodes.Length == 0)
            {
                return;
            }

            Pen edgePen = new Pen(Color.Gray, 1);
            int nodeRadius = 5;

            double minX = double.MaxValue, maxX = double.MinValue;
            double minY = double.MaxValue, maxY = double.MinValue;
            foreach (Node node in nodes)
            {
                if (node == null)
                { 
                    continue; 
                }
                if (node.x < minX)
                {
                    minX = node.x;
                }
                if (node.x > maxX)
                {
                    maxX = node.x;
                }
                if (node.y < minY) 
                { 
                    minY = node.y; 
                }
                if (node.y > maxY)
                {
                    maxY = node.y;
                }
            }

            float padding = 20f;
            float panelWidth = graphPanel.Width - 2 * padding;
            float panelHeight = graphPanel.Height - 2 * padding;
            double scaleX = panelWidth / (maxX - minX);
            double scaleY = panelHeight / (maxY - minY);
            double scale = Math.Min(scaleX, scaleY);

            foreach (KeyValuePair<int, List<Edge>> entry in graph)
            {
                int fromIndex = entry.Key;
                Node fromNode = nodes[fromIndex];
                if (fromNode == null)
                {
                    continue;
                }

                PointF fromPt = Transformtoscreen(fromNode.x, fromNode.y, minX, minY, scale, (int)panelHeight, (int)padding);

                foreach (Edge edge in entry.Value)
                {
                    Node toNode = nodes[edge.DistnationNode];
                    if (toNode == null)
                    { 
                        continue; 
                    }


                    PointF toPt = Transformtoscreen(toNode.x, toNode.y, minX, minY, scale, (int)panelHeight, (int)padding);
                    g.DrawLine(edgePen, fromPt, toPt);
                }
            }

            if (lastPath != null && lastPath.Count > 1)
            {
                Pen pathPen = new Pen(Color.Red, 2);
                for (int i = 0; i < lastPath.Count - 1; i++)
                {
                    Node fromNode = nodes[lastPath[i]];
                    Node toNode = nodes[lastPath[i + 1]];
                    if (fromNode == null || toNode == null)
                    {
                        continue;
                    }

                    PointF fromPt = Transformtoscreen(fromNode.x, fromNode.y, minX, minY, scale, (int)panelHeight, (int)padding);
                    PointF toPt = Transformtoscreen(toNode.x, toNode.y, minX, minY, scale, (int)panelHeight, (int)padding);
                    g.DrawLine(pathPen, fromPt, toPt);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= loadedQueries.Count)
            {
                return;
            }
            (double x1, double y1, double x2, double y2, double R) = loadedQueries[selectedIndex];

            (List<int> path, double totalTime, double vehicleDistance, double walkingDistance) =
                Map.Graph.Dijkstra.FindShortestPath(graph, nodes, x1, y1, x2, y2, R);

            lastPath = path;

            textBox1.Text = $"{totalTime:F2} mins";
            textBox2.Text = $"{(vehicleDistance + walkingDistance):F2} km";

            graphPanel.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            RunGraphQueries();

            this.DoubleBuffered = true;
            typeof(Panel)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(graphPanel, true, null);

            graphPanel.Invalidate();
        }

        

        private bool OpenFile(TextBox targetTextBox)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (!string.IsNullOrWhiteSpace(targetTextBox.Text))
                {
                    ofd.InitialDirectory = Path.GetDirectoryName(targetTextBox.Text);
                }

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    targetTextBox.Text = ofd.FileName;
                    return true;
                }
            }
            return false;
        }

        private bool SaveFile(TextBox targetTextBox)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (!string.IsNullOrWhiteSpace(targetTextBox.Text))
                {
                    sfd.InitialDirectory = Path.GetDirectoryName(targetTextBox.Text);
                }

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    targetTextBox.Text = sfd.FileName;
                    return true;
                }
            }
            return false;
        }

        

        private void BrowseMap_Click(object sender, EventArgs e)
        {
            OpenFile(txtMapPath);
        }

        private void BrowseQuery_Click(object sender, EventArgs e)
        {
            OpenFile(txtQueryPath);
        }

        private void BrowseTest_Click(object sender, EventArgs e)
        {
            OpenFile(txtTextPath);
        }

        private void BrowseOutput_Click(object sender, EventArgs e)
        {
            SaveFile(txtOutputPath);
        }

        

        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void txtOutputPath_TextChanged(object sender, EventArgs e) { }
        private void txtTestPath_TextChanged(object sender, EventArgs e) { }
        private void txtQueryPath_TextChanged(object sender, EventArgs e) { }
    }
}
