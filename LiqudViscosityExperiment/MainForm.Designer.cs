namespace LiquidViscosity
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contolPanelGroup = new System.Windows.Forms.GroupBox();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.matName = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BallDensity = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.BallRadius = new System.Windows.Forms.TrackBar();
            this.liqudChoice = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаПоЭкспериментуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.liquidSelector = new System.Windows.Forms.RadioButton();
            this.ballSelector = new System.Windows.Forms.RadioButton();
            this.bottomSelector = new System.Windows.Forms.RadioButton();
            this.tubeSelector = new System.Windows.Forms.RadioButton();
            this.AllIndicator = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.AllSlider = new System.Windows.Forms.TrackBar();
            this.AlphaIndicator = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AlphaSlider = new System.Windows.Forms.TrackBar();
            this.refresh = new System.Windows.Forms.Button();
            this.GIndicator = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BIndicator = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RIndicator = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.matComp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BSlider = new System.Windows.Forms.TrackBar();
            this.GSlider = new System.Windows.Forms.TrackBar();
            this.RSlider = new System.Windows.Forms.TrackBar();
            this.ComponentSlider = new System.Windows.Forms.TrackBar();
            this.OGLVP = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.saveMaterial = new System.Windows.Forms.Button();
            this.contolPanelGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BallDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallRadius)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComponentSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // contolPanelGroup
            // 
            this.contolPanelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.contolPanelGroup.Controls.Add(this.radiusLabel);
            this.contolPanelGroup.Controls.Add(this.matName);
            this.contolPanelGroup.Controls.Add(this.stop);
            this.contolPanelGroup.Controls.Add(this.start);
            this.contolPanelGroup.Controls.Add(this.label2);
            this.contolPanelGroup.Controls.Add(this.BallDensity);
            this.contolPanelGroup.Controls.Add(this.label1);
            this.contolPanelGroup.Controls.Add(this.BallRadius);
            this.contolPanelGroup.Controls.Add(this.liqudChoice);
            this.contolPanelGroup.Location = new System.Drawing.Point(767, 27);
            this.contolPanelGroup.Name = "contolPanelGroup";
            this.contolPanelGroup.Size = new System.Drawing.Size(229, 272);
            this.contolPanelGroup.TabIndex = 0;
            this.contolPanelGroup.TabStop = false;
            this.contolPanelGroup.Text = "Управление экспериментом";
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(93, 124);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(40, 13);
            this.radiusLabel.TabIndex = 8;
            this.radiusLabel.Text = "Radius";
            // 
            // matName
            // 
            this.matName.AutoSize = true;
            this.matName.Location = new System.Drawing.Point(47, 215);
            this.matName.Name = "matName";
            this.matName.Size = new System.Drawing.Size(132, 13);
            this.matName.TabIndex = 7;
            this.matName.Text = "Аллюминий (2700 кг/м3)";
            // 
            // stop
            // 
            this.stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stop.Enabled = false;
            this.stop.Location = new System.Drawing.Point(123, 243);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(100, 23);
            this.stop.TabIndex = 6;
            this.stop.Text = "СТОП";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.start.Location = new System.Drawing.Point(6, 243);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(100, 23);
            this.start.TabIndex = 5;
            this.start.Text = "ПУСК";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Материал шарика";
            // 
            // BallDensity
            // 
            this.BallDensity.Location = new System.Drawing.Point(7, 167);
            this.BallDensity.Maximum = 5;
            this.BallDensity.Name = "BallDensity";
            this.BallDensity.Size = new System.Drawing.Size(216, 45);
            this.BallDensity.TabIndex = 3;
            this.BallDensity.Scroll += new System.EventHandler(this.BallDensity_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Радиус шарика";
            // 
            // BallRadius
            // 
            this.BallRadius.Location = new System.Drawing.Point(7, 76);
            this.BallRadius.Maximum = 20;
            this.BallRadius.Name = "BallRadius";
            this.BallRadius.Size = new System.Drawing.Size(216, 45);
            this.BallRadius.TabIndex = 1;
            this.BallRadius.TickFrequency = 5;
            this.BallRadius.Scroll += new System.EventHandler(this.BallRadius_Scroll);
            // 
            // liqudChoice
            // 
            this.liqudChoice.FormattingEnabled = true;
            this.liqudChoice.Items.AddRange(new object[] {
            "жидкость 1",
            "жидкость 2",
            "жидкость 3"});
            this.liqudChoice.Location = new System.Drawing.Point(7, 20);
            this.liqudChoice.Name = "liqudChoice";
            this.liqudChoice.Size = new System.Drawing.Size(216, 21);
            this.liqudChoice.TabIndex = 0;
            this.liqudChoice.Text = "Выбор жидкости";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.FileToolStripMenuItem.Text = "Выход";
            this.FileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаПоЭкспериментуToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // справкаПоЭкспериментуToolStripMenuItem
            // 
            this.справкаПоЭкспериментуToolStripMenuItem.Name = "справкаПоЭкспериментуToolStripMenuItem";
            this.справкаПоЭкспериментуToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.справкаПоЭкспериментуToolStripMenuItem.Text = "Справка по эксперименту";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveMaterial);
            this.groupBox1.Controls.Add(this.liquidSelector);
            this.groupBox1.Controls.Add(this.ballSelector);
            this.groupBox1.Controls.Add(this.bottomSelector);
            this.groupBox1.Controls.Add(this.tubeSelector);
            this.groupBox1.Controls.Add(this.AllIndicator);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.AllSlider);
            this.groupBox1.Controls.Add(this.AlphaIndicator);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.AlphaSlider);
            this.groupBox1.Controls.Add(this.refresh);
            this.groupBox1.Controls.Add(this.GIndicator);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BIndicator);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RIndicator);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.matComp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BSlider);
            this.groupBox1.Controls.Add(this.GSlider);
            this.groupBox1.Controls.Add(this.RSlider);
            this.groupBox1.Controls.Add(this.ComponentSlider);
            this.groupBox1.Location = new System.Drawing.Point(767, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 430);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка материала";
            // 
            // liquidSelector
            // 
            this.liquidSelector.AutoSize = true;
            this.liquidSelector.Location = new System.Drawing.Point(123, 339);
            this.liquidSelector.Name = "liquidSelector";
            this.liquidSelector.Size = new System.Drawing.Size(53, 17);
            this.liquidSelector.TabIndex = 15;
            this.liquidSelector.Text = "Liquid";
            this.liquidSelector.UseVisualStyleBackColor = true;
            this.liquidSelector.CheckedChanged += new System.EventHandler(this.tubeiSelector_CheckedChanged);
            // 
            // ballSelector
            // 
            this.ballSelector.AutoSize = true;
            this.ballSelector.Location = new System.Drawing.Point(123, 366);
            this.ballSelector.Name = "ballSelector";
            this.ballSelector.Size = new System.Drawing.Size(42, 17);
            this.ballSelector.TabIndex = 15;
            this.ballSelector.Text = "Ball";
            this.ballSelector.UseVisualStyleBackColor = true;
            this.ballSelector.CheckedChanged += new System.EventHandler(this.ballSelector_CheckedChanged);
            // 
            // bottomSelector
            // 
            this.bottomSelector.AutoSize = true;
            this.bottomSelector.Location = new System.Drawing.Point(21, 366);
            this.bottomSelector.Name = "bottomSelector";
            this.bottomSelector.Size = new System.Drawing.Size(58, 17);
            this.bottomSelector.TabIndex = 15;
            this.bottomSelector.Text = "Bottom";
            this.bottomSelector.UseVisualStyleBackColor = true;
            this.bottomSelector.CheckedChanged += new System.EventHandler(this.bottomSelector_CheckedChanged);
            // 
            // tubeSelector
            // 
            this.tubeSelector.AutoSize = true;
            this.tubeSelector.Checked = true;
            this.tubeSelector.Location = new System.Drawing.Point(21, 340);
            this.tubeSelector.Name = "tubeSelector";
            this.tubeSelector.Size = new System.Drawing.Size(50, 17);
            this.tubeSelector.TabIndex = 14;
            this.tubeSelector.TabStop = true;
            this.tubeSelector.Text = "Tube";
            this.tubeSelector.UseVisualStyleBackColor = true;
            this.tubeSelector.CheckedChanged += new System.EventHandler(this.tubeSelector_CheckedChanged);
            // 
            // AllIndicator
            // 
            this.AllIndicator.AutoSize = true;
            this.AllIndicator.Location = new System.Drawing.Point(207, 302);
            this.AllIndicator.Name = "AllIndicator";
            this.AllIndicator.Size = new System.Drawing.Size(28, 13);
            this.AllIndicator.TabIndex = 13;
            this.AllIndicator.Text = "1.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "All";
            // 
            // AllSlider
            // 
            this.AllSlider.Location = new System.Drawing.Point(21, 288);
            this.AllSlider.Maximum = 100;
            this.AllSlider.Name = "AllSlider";
            this.AllSlider.Size = new System.Drawing.Size(180, 45);
            this.AllSlider.TabIndex = 11;
            this.AllSlider.TickFrequency = 10;
            this.AllSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.AllSlider.Value = 100;
            this.AllSlider.Scroll += new System.EventHandler(this.AllSlider_Scroll);
            // 
            // AlphaIndicator
            // 
            this.AlphaIndicator.AutoSize = true;
            this.AlphaIndicator.Location = new System.Drawing.Point(207, 251);
            this.AlphaIndicator.Name = "AlphaIndicator";
            this.AlphaIndicator.Size = new System.Drawing.Size(28, 13);
            this.AlphaIndicator.TabIndex = 9;
            this.AlphaIndicator.Text = "1.00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "A";
            // 
            // AlphaSlider
            // 
            this.AlphaSlider.Location = new System.Drawing.Point(21, 237);
            this.AlphaSlider.Maximum = 100;
            this.AlphaSlider.Name = "AlphaSlider";
            this.AlphaSlider.Size = new System.Drawing.Size(180, 45);
            this.AlphaSlider.TabIndex = 7;
            this.AlphaSlider.TickFrequency = 10;
            this.AlphaSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.AlphaSlider.Value = 100;
            this.AlphaSlider.Scroll += new System.EventHandler(this.AlphaSlider_Scroll);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(6, 389);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(100, 23);
            this.refresh.TabIndex = 6;
            this.refresh.Text = "SET";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.SET_Click);
            // 
            // GIndicator
            // 
            this.GIndicator.AutoSize = true;
            this.GIndicator.Location = new System.Drawing.Point(207, 149);
            this.GIndicator.Name = "GIndicator";
            this.GIndicator.Size = new System.Drawing.Size(28, 13);
            this.GIndicator.TabIndex = 5;
            this.GIndicator.Text = "1.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "G";
            // 
            // BIndicator
            // 
            this.BIndicator.AutoSize = true;
            this.BIndicator.Location = new System.Drawing.Point(207, 200);
            this.BIndicator.Name = "BIndicator";
            this.BIndicator.Size = new System.Drawing.Size(28, 13);
            this.BIndicator.TabIndex = 5;
            this.BIndicator.Text = "1.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "B";
            // 
            // RIndicator
            // 
            this.RIndicator.AutoSize = true;
            this.RIndicator.Location = new System.Drawing.Point(207, 99);
            this.RIndicator.Name = "RIndicator";
            this.RIndicator.Size = new System.Drawing.Size(28, 13);
            this.RIndicator.TabIndex = 5;
            this.RIndicator.Text = "1.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "R";
            // 
            // matComp
            // 
            this.matComp.AutoSize = true;
            this.matComp.Location = new System.Drawing.Point(156, 45);
            this.matComp.Name = "matComp";
            this.matComp.Size = new System.Drawing.Size(45, 13);
            this.matComp.TabIndex = 5;
            this.matComp.Text = "Ambient";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Компонент";
            // 
            // BSlider
            // 
            this.BSlider.Location = new System.Drawing.Point(21, 186);
            this.BSlider.Maximum = 100;
            this.BSlider.Name = "BSlider";
            this.BSlider.Size = new System.Drawing.Size(180, 45);
            this.BSlider.TabIndex = 3;
            this.BSlider.TickFrequency = 10;
            this.BSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.BSlider.Value = 100;
            this.BSlider.Scroll += new System.EventHandler(this.BSlider_Scroll);
            // 
            // GSlider
            // 
            this.GSlider.Location = new System.Drawing.Point(21, 135);
            this.GSlider.Maximum = 100;
            this.GSlider.Name = "GSlider";
            this.GSlider.Size = new System.Drawing.Size(180, 45);
            this.GSlider.TabIndex = 2;
            this.GSlider.TickFrequency = 10;
            this.GSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.GSlider.Value = 100;
            this.GSlider.Scroll += new System.EventHandler(this.GSlider_Scroll);
            // 
            // RSlider
            // 
            this.RSlider.Location = new System.Drawing.Point(21, 84);
            this.RSlider.Maximum = 100;
            this.RSlider.Name = "RSlider";
            this.RSlider.Size = new System.Drawing.Size(180, 45);
            this.RSlider.TabIndex = 1;
            this.RSlider.TickFrequency = 10;
            this.RSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.RSlider.Value = 100;
            this.RSlider.Scroll += new System.EventHandler(this.RSlider_Scroll);
            // 
            // ComponentSlider
            // 
            this.ComponentSlider.LargeChange = 1;
            this.ComponentSlider.Location = new System.Drawing.Point(6, 36);
            this.ComponentSlider.Maximum = 4;
            this.ComponentSlider.Name = "ComponentSlider";
            this.ComponentSlider.Size = new System.Drawing.Size(144, 45);
            this.ComponentSlider.TabIndex = 0;
            this.ComponentSlider.Scroll += new System.EventHandler(this.ComponentSlider_Scroll);
            // 
            // OGLVP
            // 
            this.OGLVP.AccumBits = ((byte)(0));
            this.OGLVP.AutoCheckErrors = false;
            this.OGLVP.AutoFinish = false;
            this.OGLVP.AutoMakeCurrent = true;
            this.OGLVP.AutoSwapBuffers = true;
            this.OGLVP.BackColor = System.Drawing.Color.Black;
            this.OGLVP.ColorBits = ((byte)(32));
            this.OGLVP.DepthBits = ((byte)(16));
            this.OGLVP.Location = new System.Drawing.Point(0, 27);
            this.OGLVP.Name = "OGLVP";
            this.OGLVP.Size = new System.Drawing.Size(761, 708);
            this.OGLVP.StencilBits = ((byte)(0));
            this.OGLVP.TabIndex = 3;
            this.OGLVP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OGLVP_MouseDown);
            this.OGLVP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OGLVP_MouseMove);
            this.OGLVP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OGLVP_MouseUp);
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Interval = 16;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // saveMaterial
            // 
            this.saveMaterial.Location = new System.Drawing.Point(135, 389);
            this.saveMaterial.Name = "saveMaterial";
            this.saveMaterial.Size = new System.Drawing.Size(100, 23);
            this.saveMaterial.TabIndex = 16;
            this.saveMaterial.Text = "SAVE";
            this.saveMaterial.UseVisualStyleBackColor = true;
            this.saveMaterial.Click += new System.EventHandler(this.saveMaterial_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.OGLVP);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.contolPanelGroup);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Определение вязкости жидкости";
            this.Load += new System.EventHandler(this.Main_Load);
            this.contolPanelGroup.ResumeLayout(false);
            this.contolPanelGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BallDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallRadius)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComponentSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox contolPanelGroup;
        private System.Windows.Forms.ComboBox liqudChoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar BallDensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar BallRadius;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаПоЭкспериментуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label matName;
        private System.Windows.Forms.Label radiusLabel;
        private Tao.Platform.Windows.SimpleOpenGlControl OGLVP;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label matComp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar BSlider;
        private System.Windows.Forms.TrackBar GSlider;
        private System.Windows.Forms.TrackBar RSlider;
        private System.Windows.Forms.TrackBar ComponentSlider;
        private System.Windows.Forms.Label GIndicator;
        private System.Windows.Forms.Label BIndicator;
        private System.Windows.Forms.Label RIndicator;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label AlphaIndicator;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar AlphaSlider;
        private System.Windows.Forms.Label AllIndicator;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar AllSlider;
        private System.Windows.Forms.RadioButton liquidSelector;
        private System.Windows.Forms.RadioButton ballSelector;
        private System.Windows.Forms.RadioButton bottomSelector;
        private System.Windows.Forms.RadioButton tubeSelector;
        private System.Windows.Forms.Button saveMaterial;
    }
}

