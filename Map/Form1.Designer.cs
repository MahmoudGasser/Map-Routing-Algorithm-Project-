namespace Map
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            graphPanel = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            BrowseTest = new Button();
            BrowseOutput = new Button();
            BrowseQuery = new Button();
            BrowseMap = new Button();
            txtTextPath = new TextBox();
            txtOutputPath = new TextBox();
            txtQueryPath = new TextBox();
            txtMapPath = new TextBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            graphPanel.SuspendLayout();
            SuspendLayout();
            // 
            // graphPanel
            // 
            graphPanel.BackColor = SystemColors.Control;
            graphPanel.Controls.Add(label7);
            graphPanel.Controls.Add(label6);
            graphPanel.Controls.Add(label5);
            graphPanel.Controls.Add(label4);
            graphPanel.Controls.Add(label3);
            graphPanel.Controls.Add(BrowseTest);
            graphPanel.Controls.Add(BrowseOutput);
            graphPanel.Controls.Add(BrowseQuery);
            graphPanel.Controls.Add(BrowseMap);
            graphPanel.Controls.Add(txtTextPath);
            graphPanel.Controls.Add(txtOutputPath);
            graphPanel.Controls.Add(txtQueryPath);
            graphPanel.Controls.Add(txtMapPath);
            graphPanel.Controls.Add(comboBox1);
            graphPanel.Controls.Add(label2);
            graphPanel.Controls.Add(label1);
            graphPanel.Controls.Add(textBox2);
            graphPanel.Controls.Add(textBox1);
            graphPanel.Controls.Add(button1);
            graphPanel.Dock = DockStyle.Fill;
            graphPanel.Location = new Point(0, 0);
            graphPanel.Margin = new Padding(4, 3, 4, 3);
            graphPanel.Name = "graphPanel";
            graphPanel.Size = new Size(1344, 582);
            graphPanel.TabIndex = 0;
            graphPanel.Paint += GraphPanel_Paint;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1137, 336);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 18;
            label7.Text = "Queries :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1148, 108);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(34, 15);
            label6.TabIndex = 17;
            label6.Text = "Test :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1132, 148);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 16;
            label5.Text = "Output File : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1145, 65);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 15;
            label4.Text = "Query :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1145, 17);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 14;
            label3.Text = "Map :";
            // 
            // BrowseTest
            // 
            BrowseTest.Location = new Point(1031, 102);
            BrowseTest.Margin = new Padding(4, 3, 4, 3);
            BrowseTest.Name = "BrowseTest";
            BrowseTest.Size = new Size(88, 27);
            BrowseTest.TabIndex = 13;
            BrowseTest.Text = "Browse";
            BrowseTest.UseVisualStyleBackColor = true;
            BrowseTest.Click += BrowseTest_Click;
            // 
            // BrowseOutput
            // 
            BrowseOutput.Location = new Point(1030, 142);
            BrowseOutput.Margin = new Padding(4, 3, 4, 3);
            BrowseOutput.Name = "BrowseOutput";
            BrowseOutput.Size = new Size(88, 27);
            BrowseOutput.TabIndex = 12;
            BrowseOutput.Text = "Browse";
            BrowseOutput.UseVisualStyleBackColor = true;
            BrowseOutput.Click += BrowseOutput_Click;
            // 
            // BrowseQuery
            // 
            BrowseQuery.Location = new Point(1031, 57);
            BrowseQuery.Margin = new Padding(4, 3, 4, 3);
            BrowseQuery.Name = "BrowseQuery";
            BrowseQuery.Size = new Size(88, 27);
            BrowseQuery.TabIndex = 11;
            BrowseQuery.Text = "Browse";
            BrowseQuery.UseVisualStyleBackColor = true;
            BrowseQuery.Click += BrowseQuery_Click;
            // 
            // BrowseMap
            // 
            BrowseMap.Location = new Point(1031, 12);
            BrowseMap.Margin = new Padding(4, 3, 4, 3);
            BrowseMap.Name = "BrowseMap";
            BrowseMap.Size = new Size(88, 27);
            BrowseMap.TabIndex = 10;
            BrowseMap.Text = "Browse";
            BrowseMap.UseVisualStyleBackColor = true;
            BrowseMap.Click += BrowseMap_Click;
            // 
            // txtTextPath
            // 
            txtTextPath.Location = new Point(1216, 102);
            txtTextPath.Margin = new Padding(4, 3, 4, 3);
            txtTextPath.Name = "txtTextPath";
            txtTextPath.Size = new Size(116, 23);
            txtTextPath.TabIndex = 9;
            txtTextPath.TextChanged += txtOutputPath_TextChanged;
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(1215, 145);
            txtOutputPath.Margin = new Padding(4, 3, 4, 3);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(116, 23);
            txtOutputPath.TabIndex = 8;
            txtOutputPath.TextChanged += txtTestPath_TextChanged;
            // 
            // txtQueryPath
            // 
            txtQueryPath.Location = new Point(1216, 57);
            txtQueryPath.Margin = new Padding(4, 3, 4, 3);
            txtQueryPath.Name = "txtQueryPath";
            txtQueryPath.Size = new Size(116, 23);
            txtQueryPath.TabIndex = 7;
            txtQueryPath.TextChanged += txtQueryPath_TextChanged;
            // 
            // txtMapPath
            // 
            txtMapPath.Location = new Point(1216, 14);
            txtMapPath.Margin = new Padding(4, 3, 4, 3);
            txtMapPath.Name = "txtMapPath";
            txtMapPath.Size = new Size(116, 23);
            txtMapPath.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1206, 333);
            comboBox1.Margin = new Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(115, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1103, 474);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 4;
            label2.Text = "Total Distance :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1124, 417);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 3;
            label1.Text = "TotalTime :";
            label1.Click += label1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1206, 468);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(116, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1206, 414);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(116, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(563, 533);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(88, 27);
            button1.TabIndex = 0;
            button1.Text = "Run Queries";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1344, 582);
            Controls.Add(graphPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Map Routing";
            Load += Form1_Load;
            graphPanel.ResumeLayout(false);
            graphPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel graphPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtTextPath;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.TextBox txtQueryPath;
        private System.Windows.Forms.TextBox txtMapPath;
        private System.Windows.Forms.Button BrowseTest;
        private System.Windows.Forms.Button BrowseOutput;
        private System.Windows.Forms.Button BrowseQuery;
        private System.Windows.Forms.Button BrowseMap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Label label7;
    }
}