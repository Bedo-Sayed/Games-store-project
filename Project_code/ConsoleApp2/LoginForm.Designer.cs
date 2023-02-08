namespace ConsoleApp2
{
    partial class LoginForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkPasswordLabel = new System.Windows.Forms.Label();
            this.signUpOption = new System.Windows.Forms.Button();
            this.signInOption = new System.Windows.Forms.Button();
            this.addressLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.seeCheckPassword = new System.Windows.Forms.CheckBox();
            this.seePassword = new System.Windows.Forms.CheckBox();
            this.address = new System.Windows.Forms.TextBox();
            this.country = new System.Windows.Forms.ComboBox();
            this.birthday = new System.Windows.Forms.DateTimePicker();
            this.checkPassword = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.signUp = new System.Windows.Forms.Button();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.signIn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxAdmin);
            this.panel1.Controls.Add(this.checkPasswordLabel);
            this.panel1.Controls.Add(this.signUpOption);
            this.panel1.Controls.Add(this.signInOption);
            this.panel1.Controls.Add(this.addressLabel);
            this.panel1.Controls.Add(this.countryLabel);
            this.panel1.Controls.Add(this.birthdayLabel);
            this.panel1.Controls.Add(this.passwordLabel);
            this.panel1.Controls.Add(this.emailLabel);
            this.panel1.Controls.Add(this.lastNameLabel);
            this.panel1.Controls.Add(this.firstNameLabel);
            this.panel1.Controls.Add(this.seeCheckPassword);
            this.panel1.Controls.Add(this.seePassword);
            this.panel1.Controls.Add(this.address);
            this.panel1.Controls.Add(this.country);
            this.panel1.Controls.Add(this.birthday);
            this.panel1.Controls.Add(this.checkPassword);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.email);
            this.panel1.Controls.Add(this.lastName);
            this.panel1.Controls.Add(this.firstName);
            this.panel1.Controls.Add(this.signUp);
            this.panel1.Controls.Add(this.signIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 73;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkPasswordLabel
            // 
            this.checkPasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkPasswordLabel.AutoSize = true;
            this.checkPasswordLabel.Location = new System.Drawing.Point(172, 203);
            this.checkPasswordLabel.Name = "checkPasswordLabel";
            this.checkPasswordLabel.Size = new System.Drawing.Size(85, 13);
            this.checkPasswordLabel.TabIndex = 94;
            this.checkPasswordLabel.Text = "Check Password";
            // 
            // signUpOption
            // 
            this.signUpOption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.signUpOption.Location = new System.Drawing.Point(410, 63);
            this.signUpOption.Name = "signUpOption";
            this.signUpOption.Size = new System.Drawing.Size(154, 50);
            this.signUpOption.TabIndex = 93;
            this.signUpOption.Text = "Create new account";
            this.signUpOption.UseVisualStyleBackColor = true;
            this.signUpOption.Click += new System.EventHandler(this.signUpOption_Click);
            // 
            // signInOption
            // 
            this.signInOption.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.signInOption.Font = new System.Drawing.Font("Tahoma", 8F);
            this.signInOption.Location = new System.Drawing.Point(257, 63);
            this.signInOption.Name = "signInOption";
            this.signInOption.Size = new System.Drawing.Size(154, 50);
            this.signInOption.TabIndex = 92;
            this.signInOption.Text = "Already have an account";
            this.signInOption.UseVisualStyleBackColor = true;
            this.signInOption.Click += new System.EventHandler(this.signInOption_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(210, 282);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(46, 13);
            this.addressLabel.TabIndex = 91;
            this.addressLabel.Text = "Address";
            // 
            // countryLabel
            // 
            this.countryLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(210, 257);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(46, 13);
            this.countryLabel.TabIndex = 90;
            this.countryLabel.Text = "Country";
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.birthdayLabel.AutoSize = true;
            this.birthdayLabel.Location = new System.Drawing.Point(209, 230);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(47, 13);
            this.birthdayLabel.TabIndex = 89;
            this.birthdayLabel.Text = "Birthday";
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(203, 181);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 88;
            this.passwordLabel.Text = "Password";
            // 
            // emailLabel
            // 
            this.emailLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(219, 156);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(31, 13);
            this.emailLabel.TabIndex = 87;
            this.emailLabel.Text = "Email";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(406, 115);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(34, 26);
            this.lastNameLabel.TabIndex = 86;
            this.lastNameLabel.Text = "Last \r\nName";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(220, 118);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(34, 26);
            this.firstNameLabel.TabIndex = 85;
            this.firstNameLabel.Text = "First\r\nName";
            // 
            // seeCheckPassword
            // 
            this.seeCheckPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.seeCheckPassword.AutoSize = true;
            this.seeCheckPassword.Location = new System.Drawing.Point(552, 203);
            this.seeCheckPassword.Name = "seeCheckPassword";
            this.seeCheckPassword.Size = new System.Drawing.Size(15, 14);
            this.seeCheckPassword.TabIndex = 84;
            this.seeCheckPassword.UseVisualStyleBackColor = true;
            this.seeCheckPassword.CheckedChanged += new System.EventHandler(this.seeCheckPassword_CheckedChanged);
            // 
            // seePassword
            // 
            this.seePassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.seePassword.AutoSize = true;
            this.seePassword.Location = new System.Drawing.Point(552, 178);
            this.seePassword.Name = "seePassword";
            this.seePassword.Size = new System.Drawing.Size(15, 14);
            this.seePassword.TabIndex = 83;
            this.seePassword.UseVisualStyleBackColor = true;
            this.seePassword.CheckedChanged += new System.EventHandler(this.seePassword_CheckedChanged);
            // 
            // address
            // 
            this.address.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.address.ForeColor = System.Drawing.SystemColors.WindowText;
            this.address.Location = new System.Drawing.Point(257, 275);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(309, 20);
            this.address.TabIndex = 82;
            // 
            // country
            // 
            this.country.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.country.ForeColor = System.Drawing.SystemColors.WindowText;
            this.country.FormattingEnabled = true;
            this.country.Location = new System.Drawing.Point(257, 250);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(309, 21);
            this.country.TabIndex = 81;
            // 
            // birthday
            // 
            this.birthday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.birthday.Location = new System.Drawing.Point(257, 225);
            this.birthday.Name = "birthday";
            this.birthday.Size = new System.Drawing.Size(309, 20);
            this.birthday.TabIndex = 80;
            // 
            // checkPassword
            // 
            this.checkPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.checkPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkPassword.Location = new System.Drawing.Point(257, 199);
            this.checkPassword.Name = "checkPassword";
            this.checkPassword.PasswordChar = '*';
            this.checkPassword.Size = new System.Drawing.Size(291, 20);
            this.checkPassword.TabIndex = 79;
            // 
            // password
            // 
            this.password.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.ForeColor = System.Drawing.SystemColors.WindowText;
            this.password.Location = new System.Drawing.Point(257, 174);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(291, 20);
            this.password.TabIndex = 78;
            // 
            // email
            // 
            this.email.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email.ForeColor = System.Drawing.SystemColors.WindowText;
            this.email.Location = new System.Drawing.Point(257, 149);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(309, 20);
            this.email.TabIndex = 77;
            // 
            // lastName
            // 
            this.lastName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lastName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lastName.Location = new System.Drawing.Point(444, 121);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(121, 20);
            this.lastName.TabIndex = 76;
            // 
            // firstName
            // 
            this.firstName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.firstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.firstName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.firstName.Location = new System.Drawing.Point(257, 124);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(126, 20);
            this.firstName.TabIndex = 75;
            // 
            // signUp
            // 
            this.signUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.signUp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.signUp.Location = new System.Drawing.Point(413, 300);
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(152, 42);
            this.signUp.TabIndex = 74;
            this.signUp.Text = "Sign Up";
            this.signUp.UseVisualStyleBackColor = true;
            this.signUp.Click += new System.EventHandler(this.signUp_Click);
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(257, 314);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(60, 17);
            this.checkBoxAdmin.TabIndex = 95;
            this.checkBoxAdmin.Text = "Admin?";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            // 
            // signIn
            // 
            this.signIn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.signIn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.signIn.Location = new System.Drawing.Point(259, 203);
            this.signIn.Name = "signIn";
            this.signIn.Size = new System.Drawing.Size(152, 42);
            this.signIn.TabIndex = 73;
            this.signIn.Text = "Sign In";
            this.signIn.UseVisualStyleBackColor = true;
            this.signIn.Click += new System.EventHandler(this.signIn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LoginForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Move += new System.EventHandler(this.LoginForm_Move);
            this.Resize += new System.EventHandler(this.LoginForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label checkPasswordLabel;
        private System.Windows.Forms.Button signUpOption;
        private System.Windows.Forms.Button signInOption;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.CheckBox seeCheckPassword;
        private System.Windows.Forms.CheckBox seePassword;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.ComboBox country;
        private System.Windows.Forms.DateTimePicker birthday;
        private System.Windows.Forms.TextBox checkPassword;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.Button signUp;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.Button signIn;
    }
}