using System.Windows.Forms;

ApplicationConfiguration.Initialize();

Form form = new Form();

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
form.Controls.Add(pb);

form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

form.KeyDown += (o, e) =>
{
    if (e.KeyCode == Keys.Escape)
    {
        Application.Exit();
    }
};

Application.Run(form);