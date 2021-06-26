using PurchaseSystem.Models;
using PurchaseSystem.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseSystemWinForm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //擷取使用者的帳號與密碼 放入acc及pwd變數
            string acc = this.TextBoxacc.Text;
            string pwd = this.TextBoxpwd.Text;
            if (string.IsNullOrWhiteSpace(acc))
                this.LblError.Text = "帳號不可為空";
            else
                this.LblError.Text = "";
            if (string.IsNullOrWhiteSpace(acc))
                this.LblError.Text = "密碼不可為空";
            else
                this.LblError.Text = "";


            //判斷登入資訊是否為真 比較後如果為真 真為True
            bool isSuccess = TryLogIn(acc, pwd);
            //如果是True 則跳轉到登入首頁
            if (isSuccess)
            {
                LblError.Text = "";
                Index newform = new Index();
                newform.main = this;
                newform.Show();
                this.TextBoxacc.Text = "";
                this.TextBoxpwd.Text = "";
                this.Hide();
            }
            else
            {
                LblError.Text = "帳號或密碼輸入錯誤，請重新輸入";
            }
        }

        public bool HasLogIned()
        {
            //定義變數取得登入狀態的Session，後面接as LogInfo 前面var判斷型別才不會出錯。 
            var val = Program.wLogInfo.user_acc;
            //檢查變數內有值且為true回傳true,否則回傳false
            if (val != null)
                return true;
            else
                return false;
        }

        public bool TryLogIn(string Account, string Password)
        {
            //若已是登入狀態則回傳true
            if (HasLogIned())
                return true;
            //從資料庫裡撈出符合帳號的資料,若沒有則回傳FALSE
            ContextModel getaccount = new ContextModel();
            User dtuserAccount = getaccount.Users.Where(obj => obj.user_acc == Account).FirstOrDefault();
            if (dtuserAccount == null)
                return false;
            if (dtuserAccount == null || string.Compare(Password, dtuserAccount.user_pwd, false) != 0)
                return false;

            Program.wLogInfo.user_id = dtuserAccount.user_id;
            Program.wLogInfo.user_pri = dtuserAccount.user_pri;
            Program.wLogInfo.user_acc = dtuserAccount.user_acc;

            return true;


        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.TextBoxacc.Text = "";
            this.TextBoxpwd.Text = "";
        }
    }
}
