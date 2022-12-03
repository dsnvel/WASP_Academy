namespace Safe;

public partial class MainPage : ContentPage
{
    private int _value;
    private const int password = 1234;
    public MainPage()
	{
		InitializeComponent();
	}

    private void DigitClicked(object sender, EventArgs e)
    {
        DisplayLabel.Text += (sender as Button).Text;
    }

    private void ConfirmClicked(object sender, EventArgs e)
    {
        _value = Convert.ToInt32(DisplayLabel.Text);
        //_action = Convert.ToChar((sender as Button).Text);
        //DisplayLabel.Text += '\n';
        if (_value == password)
        {
            DisplayLabel.Text = "Password is correct!";
        }
        else
        {
            DisplayLabel.Text = "Wrong password!";
        }
    }

    private void DeclineClicked(object sender, EventArgs e)
    {
        DisplayLabel.Text = "";
    }
}

