namespace LiquidViscosity
{
    partial class MatSettings
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
            this.saveMaterial = new System.Windows.Forms.Button();
            this.liquidSelector = new System.Windows.Forms.RadioButton();
            this.ballSelector = new System.Windows.Forms.RadioButton();
            this.bottomSelector = new System.Windows.Forms.RadioButton();
            this.tubeSelector = new System.Windows.Forms.RadioButton();
            this.AllIndicator = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AllSlider = new System.Windows.Forms.TrackBar();
            this.AlphaIndicator = new System.Windows.Forms.Label();
            this.AlphaSlider = new System.Windows.Forms.TrackBar();
            this.Set = new System.Windows.Forms.Button();
            this.GIndicator = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BIndicator = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RIndicator = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.matComp = new System.Windows.Forms.Label();
            this.BSlider = new System.Windows.Forms.TrackBar();
            this.GSlider = new System.Windows.Forms.TrackBar();
            this.RSlider = new System.Windows.Forms.TrackBar();
            this.ComponentSlider = new System.Windows.Forms.TrackBar();
            this.ElementContainer = new System.Windows.Forms.GroupBox();
            this.ComponentContainer = new System.Windows.Forms.GroupBox();
            this.ColorContainer = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SetDefault = new System.Windows.Forms.Button();
            this.tableSelector = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.AllSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComponentSlider)).BeginInit();
            this.ElementContainer.SuspendLayout();
            this.ComponentContainer.SuspendLayout();
            this.ColorContainer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveMaterial
            // 
            this.saveMaterial.Location = new System.Drawing.Point(108, 485);
            this.saveMaterial.Name = "saveMaterial";
            this.saveMaterial.Size = new System.Drawing.Size(92, 23);
            this.saveMaterial.TabIndex = 16;
            this.saveMaterial.Text = "Сохранить";
            this.saveMaterial.UseVisualStyleBackColor = true;
            this.saveMaterial.Click += new System.EventHandler(this.saveMaterial_Click);
            // 
            // liquidSelector
            // 
            this.liquidSelector.AutoSize = true;
            this.liquidSelector.Location = new System.Drawing.Point(108, 18);
            this.liquidSelector.Name = "liquidSelector";
            this.liquidSelector.Size = new System.Drawing.Size(77, 17);
            this.liquidSelector.TabIndex = 15;
            this.liquidSelector.Text = "Жидкость";
            this.liquidSelector.UseVisualStyleBackColor = true;
            this.liquidSelector.CheckedChanged += new System.EventHandler(this.liquidSelector_CheckedChanged);
            // 
            // ballSelector
            // 
            this.ballSelector.AutoSize = true;
            this.ballSelector.Location = new System.Drawing.Point(108, 45);
            this.ballSelector.Name = "ballSelector";
            this.ballSelector.Size = new System.Drawing.Size(58, 17);
            this.ballSelector.TabIndex = 15;
            this.ballSelector.Text = "Шарик";
            this.ballSelector.UseVisualStyleBackColor = true;
            this.ballSelector.CheckedChanged += new System.EventHandler(this.ballSelector_CheckedChanged);
            // 
            // bottomSelector
            // 
            this.bottomSelector.AutoSize = true;
            this.bottomSelector.Location = new System.Drawing.Point(6, 45);
            this.bottomSelector.Name = "bottomSelector";
            this.bottomSelector.Size = new System.Drawing.Size(80, 17);
            this.bottomSelector.TabIndex = 15;
            this.bottomSelector.Text = "Подставка";
            this.bottomSelector.UseVisualStyleBackColor = true;
            this.bottomSelector.CheckedChanged += new System.EventHandler(this.bottomSelector_CheckedChanged);
            // 
            // tubeSelector
            // 
            this.tubeSelector.AutoSize = true;
            this.tubeSelector.Checked = true;
            this.tubeSelector.Location = new System.Drawing.Point(6, 18);
            this.tubeSelector.Name = "tubeSelector";
            this.tubeSelector.Size = new System.Drawing.Size(61, 17);
            this.tubeSelector.TabIndex = 14;
            this.tubeSelector.TabStop = true;
            this.tubeSelector.Text = "Трубка";
            this.tubeSelector.UseVisualStyleBackColor = true;
            this.tubeSelector.CheckedChanged += new System.EventHandler(this.tubeSelector_CheckedChanged);
            // 
            // AllIndicator
            // 
            this.AllIndicator.AutoSize = true;
            this.AllIndicator.Location = new System.Drawing.Point(238, 188);
            this.AllIndicator.Name = "AllIndicator";
            this.AllIndicator.Size = new System.Drawing.Size(28, 13);
            this.AllIndicator.TabIndex = 13;
            this.AllIndicator.Text = "1.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Все";
            // 
            // AllSlider
            // 
            this.AllSlider.Location = new System.Drawing.Point(37, 172);
            this.AllSlider.Maximum = 100;
            this.AllSlider.Name = "AllSlider";
            this.AllSlider.Size = new System.Drawing.Size(195, 45);
            this.AllSlider.TabIndex = 11;
            this.AllSlider.TickFrequency = 10;
            this.AllSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.AllSlider.Value = 100;
            this.AllSlider.Scroll += new System.EventHandler(this.AllSlider_Scroll);
            // 
            // AlphaIndicator
            // 
            this.AlphaIndicator.AutoSize = true;
            this.AlphaIndicator.Location = new System.Drawing.Point(238, 35);
            this.AlphaIndicator.Name = "AlphaIndicator";
            this.AlphaIndicator.Size = new System.Drawing.Size(28, 13);
            this.AlphaIndicator.TabIndex = 9;
            this.AlphaIndicator.Text = "1.00";
            // 
            // AlphaSlider
            // 
            this.AlphaSlider.Location = new System.Drawing.Point(6, 19);
            this.AlphaSlider.Maximum = 100;
            this.AlphaSlider.Name = "AlphaSlider";
            this.AlphaSlider.Size = new System.Drawing.Size(226, 45);
            this.AlphaSlider.TabIndex = 7;
            this.AlphaSlider.TickFrequency = 10;
            this.AlphaSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.AlphaSlider.Value = 100;
            this.AlphaSlider.Scroll += new System.EventHandler(this.AlphaSlider_Scroll);
            // 
            // Set
            // 
            this.Set.Location = new System.Drawing.Point(12, 485);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(89, 23);
            this.Set.TabIndex = 6;
            this.Set.Text = "Задать";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // GIndicator
            // 
            this.GIndicator.AutoSize = true;
            this.GIndicator.Location = new System.Drawing.Point(238, 88);
            this.GIndicator.Name = "GIndicator";
            this.GIndicator.Size = new System.Drawing.Size(28, 13);
            this.GIndicator.TabIndex = 5;
            this.GIndicator.Text = "1.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "G";
            // 
            // BIndicator
            // 
            this.BIndicator.AutoSize = true;
            this.BIndicator.Location = new System.Drawing.Point(238, 139);
            this.BIndicator.Name = "BIndicator";
            this.BIndicator.Size = new System.Drawing.Size(28, 13);
            this.BIndicator.TabIndex = 5;
            this.BIndicator.Text = "1.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "B";
            // 
            // RIndicator
            // 
            this.RIndicator.AutoSize = true;
            this.RIndicator.Location = new System.Drawing.Point(238, 37);
            this.RIndicator.Name = "RIndicator";
            this.RIndicator.Size = new System.Drawing.Size(28, 13);
            this.RIndicator.TabIndex = 5;
            this.RIndicator.Text = "1.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "R";
            // 
            // matComp
            // 
            this.matComp.AutoSize = true;
            this.matComp.Location = new System.Drawing.Point(214, 29);
            this.matComp.Name = "matComp";
            this.matComp.Size = new System.Drawing.Size(45, 13);
            this.matComp.TabIndex = 5;
            this.matComp.Text = "Ambient";
            // 
            // BSlider
            // 
            this.BSlider.Location = new System.Drawing.Point(37, 123);
            this.BSlider.Maximum = 100;
            this.BSlider.Name = "BSlider";
            this.BSlider.Size = new System.Drawing.Size(195, 45);
            this.BSlider.TabIndex = 3;
            this.BSlider.TickFrequency = 10;
            this.BSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.BSlider.Value = 100;
            this.BSlider.Scroll += new System.EventHandler(this.BSlider_Scroll);
            // 
            // GSlider
            // 
            this.GSlider.Location = new System.Drawing.Point(37, 72);
            this.GSlider.Maximum = 100;
            this.GSlider.Name = "GSlider";
            this.GSlider.Size = new System.Drawing.Size(195, 45);
            this.GSlider.TabIndex = 2;
            this.GSlider.TickFrequency = 10;
            this.GSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.GSlider.Value = 100;
            this.GSlider.Scroll += new System.EventHandler(this.GSlider_Scroll);
            // 
            // RSlider
            // 
            this.RSlider.Location = new System.Drawing.Point(37, 21);
            this.RSlider.Maximum = 100;
            this.RSlider.Name = "RSlider";
            this.RSlider.Size = new System.Drawing.Size(195, 45);
            this.RSlider.TabIndex = 1;
            this.RSlider.TickFrequency = 10;
            this.RSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.RSlider.Value = 100;
            this.RSlider.Scroll += new System.EventHandler(this.RSlider_Scroll);
            // 
            // ComponentSlider
            // 
            this.ComponentSlider.LargeChange = 1;
            this.ComponentSlider.Location = new System.Drawing.Point(6, 19);
            this.ComponentSlider.Maximum = 4;
            this.ComponentSlider.Name = "ComponentSlider";
            this.ComponentSlider.Size = new System.Drawing.Size(202, 45);
            this.ComponentSlider.TabIndex = 0;
            this.ComponentSlider.Scroll += new System.EventHandler(this.ComponentSlider_Scroll);
            // 
            // ElementContainer
            // 
            this.ElementContainer.Controls.Add(this.tableSelector);
            this.ElementContainer.Controls.Add(this.tubeSelector);
            this.ElementContainer.Controls.Add(this.liquidSelector);
            this.ElementContainer.Controls.Add(this.bottomSelector);
            this.ElementContainer.Controls.Add(this.ballSelector);
            this.ElementContainer.Location = new System.Drawing.Point(12, 12);
            this.ElementContainer.Name = "ElementContainer";
            this.ElementContainer.Size = new System.Drawing.Size(283, 75);
            this.ElementContainer.TabIndex = 4;
            this.ElementContainer.TabStop = false;
            this.ElementContainer.Text = "Элемент установки";
            // 
            // ComponentContainer
            // 
            this.ComponentContainer.Controls.Add(this.ComponentSlider);
            this.ComponentContainer.Controls.Add(this.matComp);
            this.ComponentContainer.Location = new System.Drawing.Point(12, 93);
            this.ComponentContainer.Name = "ComponentContainer";
            this.ComponentContainer.Size = new System.Drawing.Size(283, 70);
            this.ComponentContainer.TabIndex = 5;
            this.ComponentContainer.TabStop = false;
            this.ComponentContainer.Text = "Компонент цвета";
            // 
            // ColorContainer
            // 
            this.ColorContainer.Controls.Add(this.RSlider);
            this.ColorContainer.Controls.Add(this.AllIndicator);
            this.ColorContainer.Controls.Add(this.GSlider);
            this.ColorContainer.Controls.Add(this.label10);
            this.ColorContainer.Controls.Add(this.BSlider);
            this.ColorContainer.Controls.Add(this.AllSlider);
            this.ColorContainer.Controls.Add(this.label4);
            this.ColorContainer.Controls.Add(this.RIndicator);
            this.ColorContainer.Controls.Add(this.label5);
            this.ColorContainer.Controls.Add(this.BIndicator);
            this.ColorContainer.Controls.Add(this.label6);
            this.ColorContainer.Controls.Add(this.GIndicator);
            this.ColorContainer.Location = new System.Drawing.Point(12, 169);
            this.ColorContainer.Name = "ColorContainer";
            this.ColorContainer.Size = new System.Drawing.Size(283, 231);
            this.ColorContainer.TabIndex = 6;
            this.ColorContainer.TabStop = false;
            this.ColorContainer.Text = "Цвет";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AlphaSlider);
            this.groupBox3.Controls.Add(this.AlphaIndicator);
            this.groupBox3.Location = new System.Drawing.Point(12, 406);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 73);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прозрачность";
            // 
            // SetDefault
            // 
            this.SetDefault.Location = new System.Drawing.Point(206, 485);
            this.SetDefault.Name = "SetDefault";
            this.SetDefault.Size = new System.Drawing.Size(89, 23);
            this.SetDefault.TabIndex = 17;
            this.SetDefault.Text = "По умолчанию";
            this.SetDefault.UseVisualStyleBackColor = true;
            // 
            // tableSelector
            // 
            this.tableSelector.AutoSize = true;
            this.tableSelector.Location = new System.Drawing.Point(217, 18);
            this.tableSelector.Name = "tableSelector";
            this.tableSelector.Size = new System.Drawing.Size(49, 17);
            this.tableSelector.TabIndex = 16;
            this.tableSelector.TabStop = true;
            this.tableSelector.Text = "Стол";
            this.tableSelector.UseVisualStyleBackColor = true;
            this.tableSelector.CheckedChanged += new System.EventHandler(this.tableSelector_CheckedChanged);
            // 
            // MatSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 518);
            this.Controls.Add(this.SetDefault);
            this.Controls.Add(this.saveMaterial);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Set);
            this.Controls.Add(this.ColorContainer);
            this.Controls.Add(this.ComponentContainer);
            this.Controls.Add(this.ElementContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MatSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки внешнего вида";
            ((System.ComponentModel.ISupportInitialize)(this.AllSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComponentSlider)).EndInit();
            this.ElementContainer.ResumeLayout(false);
            this.ElementContainer.PerformLayout();
            this.ComponentContainer.ResumeLayout(false);
            this.ComponentContainer.PerformLayout();
            this.ColorContainer.ResumeLayout(false);
            this.ColorContainer.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveMaterial;
        private System.Windows.Forms.RadioButton liquidSelector;
        private System.Windows.Forms.RadioButton ballSelector;
        private System.Windows.Forms.RadioButton bottomSelector;
        private System.Windows.Forms.RadioButton tubeSelector;
        private System.Windows.Forms.Label AllIndicator;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar AllSlider;
        private System.Windows.Forms.Label AlphaIndicator;
        private System.Windows.Forms.TrackBar AlphaSlider;
        private System.Windows.Forms.Button Set;
        private System.Windows.Forms.Label GIndicator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label BIndicator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label RIndicator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label matComp;
        private System.Windows.Forms.TrackBar BSlider;
        private System.Windows.Forms.TrackBar GSlider;
        private System.Windows.Forms.TrackBar RSlider;
        private System.Windows.Forms.TrackBar ComponentSlider;
        private System.Windows.Forms.GroupBox ElementContainer;
        private System.Windows.Forms.GroupBox ComponentContainer;
        private System.Windows.Forms.GroupBox ColorContainer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button SetDefault;
        private System.Windows.Forms.RadioButton tableSelector;
    }
}