using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_Machine
{
    

    public partial class BankMachineGUI : Form
    {
        #region Declared_Variables
        string mode = "CreatePIN";
        bool PINCheck = false;
        private bool disabled = false;
        private bool enabled = true;
        private string storedPIN;
        PinPadInput PIN = new PinPadInput();
        AccountBalance balance = new AccountBalance();
        #endregion


        #region Functions
        public BankMachineGUI()
        {
            InitializeComponent();
            Mode(mode);
        }

        public void enableDisableButtons()
        {
            disabled = !disabled;
            enabled = !enabled;

            btnBalance.Enabled = enabled;
            btnDeposit.Enabled = enabled;
            btnWithdrawal.Enabled = enabled;
            btnPIN1.Enabled = disabled;
            btnPIN2.Enabled = disabled;
            btnPIN3.Enabled = disabled;
            btnPIN4.Enabled = disabled;
            btnPIN5.Enabled = disabled;
            btnPIN6.Enabled = disabled;
            btnPIN7.Enabled = disabled;
            btnPIN8.Enabled = disabled;
            btnPIN9.Enabled = disabled;
            btnPIN0.Enabled = disabled;
            btnReset.Enabled = disabled;
            btnEnter.Enabled = disabled;
        }

        

        public void Mode(string mode)
        {
            switch (mode)
            {
                case "CreatePIN":
                    //turn PIN Pad on and deposit, withdrawal, balance buttons off
                    enableDisableButtons();
                    tbOutput.Text = "Welcome! Create a new PIN";
                    break;
                case "SuccessfulPIN":
                    //turn PIN Pad off and d, w, b buttons on
                    enableDisableButtons();
                    tbOutput.Text = "Thank You! How can we help you?";
                    break;
                case "Deposit":
                    //turn PIN Pad on and d, w, b button off
                    enableDisableButtons();
                    PINCheck = true;
                    PIN.newPINPadInput("Reset");
                    tbOutput.Text = "Please enter your PIN";
                    break;
                case "Withdraw":
                    //turn PIN Pad on and d, w, b button off
                    enableDisableButtons();
                    PINCheck = true;
                    PIN.newPINPadInput("Reset");
                    tbOutput.Text = "Please enter your PIN";
                    break;
                case "InsufficientFunds":
                    //turn PIN Pad off and d, w, b buttons on
                    enableDisableButtons();
                    tbOutput.Text = "Insufficient Funds!";
                    break;
                default:
                    break;

            }
        }

        // this displays the dollar amount to be displayed in the text box when withdrawing or depositing
        public void dollarAmountInTextBox(string input)
        {
            if ((mode == "Deposit" || mode == "Withdraw") && PINCheck == false)
            {
                // if the output still shows "how much do you want to deposit(withdraw)?"
                // or if the Reset button 
                if (tbOutput.TextLength > 20)
                {
                    tbOutput.Text = "$";
                }

                // output the next number or reset to $
                if (input != "Reset")
                {
                    tbOutput.Text += input;
                }
                else
                {
                    tbOutput.Text = "$";
                }
                
            }
            
            
        }
        #endregion



        #region Button_Clicks
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbOutput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            mode = "Deposit";
            Mode(mode);

        }

        private void btnWithdrawal_Click(object sender, EventArgs e)
        {
            mode = "Withdraw";
            Mode(mode);
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            tbOutput.Text = $"Your balance is ${balance.getBalance()}";
        }

        

        
        private void btnReset_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("Reset");
            dollarAmountInTextBox("Reset");
        }

        
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (mode == "CreatePIN")
            {
                storedPIN = PIN.fullPINValue();
                mode = "SuccessfulPIN";
                Mode(mode);
            }
            else if (PINCheck)
            {
                if (PIN.fullPINValue() == storedPIN)
                {
                    tbOutput.Text = $"PIN accepted. {this.mode} how much?";
                    PINCheck = false;
                    PIN.newPINPadInput("Reset");
                }
                else
                {
                    tbOutput.Text = "PIN not accepted! Try again";
                    PIN.newPINPadInput("Reset");
                }
            }
            else if (mode == "Deposit")
            {
                balance.deposit(float.Parse(PIN.fullPINValue()));
                Mode("SuccessfulPIN");
            }
            else if (mode == "Withdraw")
            {
                float error = balance.withdrawal(float.Parse(PIN.fullPINValue()));
                if (error != -1)
                {
                    mode = "SuccessfulPIN";
                    Mode(mode);
                }
                else
                {
                    mode = "InsufficientFunds";
                    Mode(mode);
                }
            }
               
        }
        private void btnPIN1_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("1");
            dollarAmountInTextBox("1");
        }
        private void btnPIN2_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("2");
            dollarAmountInTextBox("2");
        }

        private void btnPIN3_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("3");
            dollarAmountInTextBox("3");
        }

        private void btnPIN4_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("4");
            dollarAmountInTextBox("4");
        }

        private void btnPIN5_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("5");
            dollarAmountInTextBox("5");
        }

        private void btnPIN6_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("6");
            dollarAmountInTextBox("6");
        }

        private void btnPIN7_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("7");
            dollarAmountInTextBox("7");
        }

        private void btnPIN8_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("8");
            dollarAmountInTextBox("8");
        }

        private void btnPIN9_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("9");
            dollarAmountInTextBox("9");
        }

        private void btnPIN0_Click(object sender, EventArgs e)
        {
            PIN.newPINPadInput("0");
            dollarAmountInTextBox("0");
        }
        #endregion

    }

    #region Classes
    public class PinPadInput
    {
        List<string> Pin = new List<string>();

        public void newPINPadInput(string value)
        {
            if (value == "Reset")
            {
                Pin.Clear();
            }
            else
            {
                Pin.Add(value);
            }
        }

        public string fullPINValue()
        {
            string value = "";
            Pin.ForEach(delegate (string digit)
            {
                value += digit;    
            });
            return value;
        }
    }

    public class AccountBalance
    {
        private float balance { get; set; }

        public AccountBalance()
        {

        }

        public float getBalance()
        {
            return balance;
        }

        public void deposit(float amount)
        {
            balance += amount;
        }

        public float withdrawal(float amount)
        {
            if (amount > balance)
            {
                // return -1 to signify error
                return -1;
            }
            else
            {
                return balance -= amount;
            }
        }
    }
    #endregion
}
