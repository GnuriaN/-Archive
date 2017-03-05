namespace WFACounterSmokedCigarettes
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bnt_First = new System.Windows.Forms.Button();
            this.btn_Current = new System.Windows.Forms.Button();
            this.btn_Last = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bnt_First
            // 
            this.bnt_First.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bnt_First.Location = new System.Drawing.Point(23, 151);
            this.bnt_First.Name = "bnt_First";
            this.bnt_First.Size = new System.Drawing.Size(238, 49);
            this.bnt_First.TabIndex = 0;
            this.bnt_First.Text = "First Cigarette";
            this.bnt_First.UseVisualStyleBackColor = true;
            this.bnt_First.Click += new System.EventHandler(this.bnt_First_Click);
            // 
            // btn_Current
            // 
            this.btn_Current.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Current.Location = new System.Drawing.Point(23, 227);
            this.btn_Current.Name = "btn_Current";
            this.btn_Current.Size = new System.Drawing.Size(238, 49);
            this.btn_Current.TabIndex = 1;
            this.btn_Current.Text = "Current Cigarette";
            this.btn_Current.UseVisualStyleBackColor = true;
            this.btn_Current.Click += new System.EventHandler(this.btn_Current_Click);
            // 
            // btn_Last
            // 
            this.btn_Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Last.Location = new System.Drawing.Point(23, 302);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(238, 49);
            this.btn_Last.TabIndex = 2;
            this.btn_Last.Text = "Last Cigarette";
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выкуренно сигарет:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(215, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "---";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Сегодня:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 390);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Last);
            this.Controls.Add(this.btn_Current);
            this.Controls.Add(this.bnt_First);
            this.Name = "MainWindow";
            this.Text = "Счетчик выкуренных сигарет";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnt_First;
        private System.Windows.Forms.Button btn_Current;
        private System.Windows.Forms.Button btn_Last;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

