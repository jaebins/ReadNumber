using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadNumber
{
    public partial class ReadNumber : Form
    {
        string[] unit_korean = {"십", "백", "천", "만"};
        string[] unit_korean_etc = { "억", "조" };
        string[] num_korean = {"", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };

        bool isChange = false;

        public ReadNumber()
        {
            InitializeComponent();
        }

        private void CheckDigit()
        {
            // 입력된게 숫자가 아니라면 예외처리를 함
            if (input_Num.Text.Length > 0)
            {
                try
                {
                    int checkNum = Int32.Parse(input_Num.Text[input_Num.Text.Length - 1].ToString());
                }
                catch (Exception ex)
                {
                    input_Num.Text = input_Num.Text.Substring(0, input_Num.Text.Length - 1);
                    MessageBox.Show("숫자를 입력해주세요.");
                }
            }
        }

        private void AddComma()
        {
            isChange = true;
            string showingNum = input_Num.Text.Replace(",", "");
            if (showingNum.Length % 3 == 1 || showingNum.Length > 4) // 천단위 구분콤마 추가
            {
                int splitCnt = showingNum.Length / 3; // 콤마를 추가할 횟수
                if (showingNum.Length % 3 == 0)
                {
                    splitCnt -= 1;
                }
                for (int i = 0; i < splitCnt; i++)
                {
                    // 중간에 콤마가 주기적으로 추가되기 때문에 전체길이에 i를 빼줌
                    showingNum = showingNum.Insert((showingNum.Length - i) - 3 * (i + 1), ",");
                }
                input_Num.Text = showingNum;
            }

            input_Num.SelectionStart = input_Num.Text.Length;
        }

        private void ConvertKorean()
        {
            if (input_Num.Text.Contains(","))
            {
                string[] nums = input_Num.Text.Split(',');

                string numsToKorean = "";
                int startUnitNum = 0;

                switch (nums.Length - 1) // 단위 늘릴때 스위치문을 더 늘려야된다.
                {
                    case 1: // 1,000
                        startUnitNum = 2;
                        break;
                    case 2: // 1,000,000
                        startUnitNum = 1;
                        break;
                    case 3: // 1,000,000,000
                        startUnitNum = 0;
                        break;
                    case 4:
                        startUnitNum = 3;
                        break;
                    case 5:
                        startUnitNum = 2;
                        break;
                }

                if (nums[0].Length > 1)
                {
                    startUnitNum += nums[0].Length - 1;
                    if (startUnitNum > 3)
                    {
                        startUnitNum = (startUnitNum % 3) - 1;
                    }
                }

                string deleteCommaNum = input_Num.Text.Replace(",", "");
                int[] unitEtc_CountArr = { -100, -100 };
                bool manTrigger = false;
                string backup = "";
                bool isEtcEnd = false;

                for (int i = 0; i < deleteCommaNum.Length; i++)
                {
                    numsToKorean += num_korean[Int32.Parse(deleteCommaNum[i].ToString())]; // 숫자 추가

                    if (i != deleteCommaNum.Length - 1) // 일의 자리수가 아닐때
                    {
                        if (deleteCommaNum.Length >= 13 && i <= deleteCommaNum.Length - 13) // 조의 자리수 도달하면
                        {
                            unitEtc_CountArr[1] = unitEtc_CountArr[1] == -100 ? deleteCommaNum.Length - i : unitEtc_CountArr[1];
                            if (unitEtc_CountArr[1] == 13) // 조 자리수 카운트가 끝났을때
                            {
                                backup = unit_korean[startUnitNum];
                                unit_korean[startUnitNum] = unit_korean_etc[1];
                                isEtcEnd = true;
                            }

                            unitEtc_CountArr[1]--;
                        }
              
                        if (deleteCommaNum.Length >= 9 && (unitEtc_CountArr[1] == 13 || unitEtc_CountArr[1] == -100) && 
                            i <= deleteCommaNum.Length - 9) // 억의 자리수 도달하면
                        {
                            unitEtc_CountArr[0] = unitEtc_CountArr[0] == -100 ? deleteCommaNum.Length - i : unitEtc_CountArr[0];
                            if (unitEtc_CountArr[0] == 9) // 억 자리수 카운트가 끝났을때
                            {
                                backup = unit_korean[startUnitNum];
                                unit_korean[startUnitNum] = unit_korean_etc[0]; // 만 단위와 억 단위를 바꿔줌(충돌때문)
                                isEtcEnd = true;
                            }

                            unitEtc_CountArr[0]--;
                        }

                        if (!deleteCommaNum[i].ToString().Equals("0") || isEtcEnd) // 0 이 아닐때
                        {
                            numsToKorean += unit_korean[startUnitNum]; // 단위
                            if (deleteCommaNum.Length >= 6 && deleteCommaNum[i + 1].ToString().Equals("0") && !manTrigger &&
                                !numsToKorean[numsToKorean.Length - 1].Equals("만") && i + 4 < deleteCommaNum.Length)
                            {
                                numsToKorean += "만";
                                manTrigger = true;
                            }
                        }

                        if (isEtcEnd)
                        {
                            unit_korean[startUnitNum] = backup;
                            isEtcEnd = false;
                        }
                    }
                    
                    startUnitNum -= 1;
                    if (startUnitNum < 0)
                    {
                        startUnitNum = 3;
                    }

                    label_Result.Text = numsToKorean;
                }
            }

            isChange = false;
        }

        private void input_Num_TextChanged(object sender, EventArgs e)
        {
            if (!isChange)
            {
                CheckDigit();
                AddComma();
                ConvertKorean();
            }
        }
    }
}
