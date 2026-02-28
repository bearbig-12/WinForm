using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Login
{
    public partial class SignUP : Form
    {
        private bool isUpdating = false; // 무한 루프 방지 플래그

        public SignUP()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckBox1State();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckBox1State();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCheckBox1State();
        }

        // 개별 체크박스 상태에 따라 전체 동의 체크박스 업데이트
        private void UpdateCheckBox1State()
        {
            if (isUpdating) return;

            isUpdating = true;
            // 모두 체크되어 있으면 전체 동의도 체크, 하나라도 해제되면 전체 동의도 해제
            checkBox1.Checked = checkBox2.Checked && checkBox3.Checked && checkBox4.Checked;
            isUpdating = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true || (checkBox2.Checked && checkBox3.Checked))
            {
                CreateAcc InFo = new CreateAcc();
                InFo.Show();
            }
            else
            {
                MessageBox.Show("필수 이용약관을 전부 동의하지 않으셨습니다.");
            }

            //Application.Exit();
        }

        private void SignUP_Load(object sender, EventArgs e) // SignUP이 실행 시, 여기 작덩된 코드를 자동으로 실행 유니티 Start 같은?
        {
            string[] LanguageType = { "한국어", "English", " 日本語", "中文" };

            for(int i = 0; i < LanguageType.Count(); ++i)
            {
                comboBox1.Items.Add(LanguageType[i]);

            }
        }
        // 전체동의
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            isUpdating = true;
            if (checkBox1.Checked)
            {
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
            isUpdating = false;
        }
    }
}
