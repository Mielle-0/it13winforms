namespace it13Project.Forms;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblUsername = new Label();
        lblPassword = new Label();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        btnLogin = new Button();
        btnClear = new Button();
        SuspendLayout();
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Gadugi", 12F);
        lblUsername.Location = new Point(82, 48);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(83, 19);
        lblUsername.TabIndex = 0;
        lblUsername.Text = "Username:";
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font("Gadugi", 12F);
        lblPassword.Location = new Point(82, 123);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(79, 19);
        lblPassword.TabIndex = 1;
        lblPassword.Text = "Password:";
        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("Gadugi", 12F);
        txtUsername.Location = new Point(82, 70);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(200, 29);
        txtUsername.TabIndex = 2;
        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("Gadugi", 12F);
        txtPassword.Location = new Point(82, 145);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(200, 29);
        txtPassword.TabIndex = 3;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = Color.FromArgb(128, 255, 128);
        btnLogin.BackgroundImageLayout = ImageLayout.None;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Gadugi", 12F);
        btnLogin.Location = new Point(57, 207);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(108, 35);
        btnLogin.TabIndex = 4;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += btnLogin_Click;
        // 
        // btnClear
        // 
        btnClear.BackgroundImageLayout = ImageLayout.None;
        btnClear.FlatStyle = FlatStyle.Flat;
        btnClear.Font = new Font("Gadugi", 12F);
        btnClear.Location = new Point(205, 207);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(108, 35);
        btnClear.TabIndex = 5;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(370, 309);
        Controls.Add(btnClear);
        Controls.Add(btnLogin);
        Controls.Add(txtPassword);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(lblUsername);
        Font = new Font("Gadugi", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "User Login";
        ResumeLayout(false);
        PerformLayout();

    }

    #endregion

    // Component declarations
    private System.Windows.Forms.Label lblUsername;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnLogin;
    private System.Windows.Forms.Button btnClear;
}
