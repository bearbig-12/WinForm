using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinForm_Login
{
    public partial class CreateAcc : Form
    {
        public CreateAcc()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox5.PasswordChar = '*';

        }

        private bool ValidateID(out string errMsg)
        {
            string id = textBox1.Text;
            if(string.IsNullOrEmpty(id))
            {
                errMsg = "아이디를 입력하여 주세요.";
                return false;
            }
            else if(id.Length < 4)
            {
                errMsg = "아이디는 4자 이상이여야 합니다.";
                return false;
            }

            errMsg = "";
            return true;
        }
        private bool ValidatePW(out string errMsg)
        {

            string pw = textBox2.Text;
            List<string> conditions = new List<string>();

            if (string.IsNullOrEmpty(pw))
            {
                errMsg = "비밀번호를 입력하여 주세요.";
                return false;
            }

            if(pw.Length < 6)
            {
                conditions.Add("6자 이상");
            }
            if(!pw.Any(char.IsLower))
            {
                conditions.Add("1개 이상의 영어 소문자가");
            }
            if(!pw.Any(char.IsDigit))
            {
                conditions.Add("1개 이상의 숫자가");
            }

            string specailChars = "!@#$%^&*()_+-=[]{}|;':\",./<>?";
            if (!pw.Any(c => specailChars.Contains(c)))
            {
                conditions.Add("1개 이상의 특수 문자가");
            }

            if(conditions.Count > 0)
            {
                //String Join  = 리스트나 배열의 요소들을 하나의 문자열로 합쳐줌
                errMsg = "비밀번호는" + string.Join(", ", conditions) + "필요합니다.";
                return false;
            }

            errMsg = "";
            return true;
        }

        private bool ValidatePWAgain(out string errMsg)
        {

            string pw = textBox2.Text;
            string pwCheck = textBox5.Text;

            if (string.IsNullOrEmpty(pw))
            {
                errMsg = "비밀번호 확인을 위하여 비밀번호를 다시 입력하여 주세요.";
                return false;
            }

            if(pw != pwCheck)
            {
                errMsg = "비밀번호가 서로 다릅니다.";
                return false;
            }
            errMsg = "";
            return true;
        }
        private bool ValidateEmail(out string errMsg)
        {

            string em = textBox3.Text;
            if (string.IsNullOrEmpty(em))
            {
                errMsg = "이메일을 입력하여주세요.";
                return false;
            }
            if (!em.Contains("@") || !em.Contains("."))
            {
                errMsg = "올바른 이메일 형식이 아닙니다.";
                return false;
            }

            errMsg = "";
            return true;
        }
        private bool ValidateName(out string errorMsg)
        {
            string name = textBox6.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                errorMsg = "이름을 입력해주세요.";
                return false;
            }

            errorMsg = "";
            return true;
        }
        private bool ValidateCarrier(out string errorMsg)
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(comboBox1.Text))
            {
                errorMsg = "통신사를 선택해주세요.";
                return false;
            }

            errorMsg = "";
            return true;
        }
        private bool ValidatePhone(out string errorMsg)
        {
            string phone = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                errorMsg = "전화번호를 입력해주세요.";
                return false;
            }
            // 숫자만 포함되어 있는지 체크
            if (!phone.All(char.IsDigit))
            {
                errorMsg = "전화번호는 숫자만 입력해주세요.";
                return false;
            }
            if (phone.Length < 10 || phone.Length > 11)
            {
                errorMsg = "전화번호는 10~11자리여야 합니다.";
                return false;
            }

            errorMsg = "";
            return true;
        }

        private List<string> ValidateAll()
        {
            List<string> errors = new List<string>();

            if (!ValidateID(out string idError))
                errors.Add(idError);

            if (!ValidatePW(out string pwError))
                errors.Add(pwError);

            if (!ValidatePWAgain(out string pwCheckError))
                errors.Add(pwCheckError);

            if (!ValidateEmail(out string emailError))
                errors.Add(emailError);

            if (!ValidateName(out string nameError))
                errors.Add(nameError);

            if (!ValidateCarrier(out string carrierError))
                errors.Add(carrierError);

            if (!ValidatePhone(out string phoneError))
                errors.Add(phoneError);

            return errors;
        }





        private void button1_Click(object sender, EventArgs e)
        {
            List<string> errors = ValidateAll();

            if(errors.Count > 0)
            {
                // 에러가 있으면 메시지 출력
                MessageBox.Show(
                    string.Join("\n", errors),  // 에러들을 줄바꿈으로 연결
                    "입력 오류",                  // 제목
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;  // 여기서 종료, 다음으로 안 넘어감
            }

            MessageBox.Show("회원가입이 완료되었습니다!", "성공");

            // Application.Exit();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

      
    }
}
