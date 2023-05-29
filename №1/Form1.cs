namespace CG
{
    public partial class MyForm : Form
    {
        KernelConfiguration kernelForm = new KernelConfiguration();
        Bitmap image;
        public MyForm()
        {
            InitializeComponent();
        }

        private void îòêğûòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void ôàéëToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        

        private void èíâåğñèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void èäåàëüíûéÎòğàæàòåëüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PerfectReflector();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void ğàçìûòèåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ôèëüòğÃàóññàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void ñåïèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sepia filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ıôôåêòÑòåêëàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlassesFilter filter = new GlassesFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void óâåëè÷åíèåßğêîñòèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncreaseBrightness filter = new IncreaseBrightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ïîëóòîíîâûéÔèëüòğToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayScale filter = new GrayScale();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ïîâûøåíèåĞåçêîñòèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sharpening filter = new Sharpening();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void ñîõğàíèòüÊàêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) { 

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Ñîõğàíåíèå";
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                    image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }

            }
        }

        private void òî÷å÷íûåToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void âîëíûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WavesFilter filter = new WavesFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ôèëüòğÑîáåëÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SobelFilter filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void âûäåëåíèåÃğàíèöîïåğàòîğÙàğğàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorderSelection filter = new BorderSelection();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kernelForm = new KernelConfiguration();
            kernelForm.Show();
        }


        private void êàñòîìíûéÔèëüòğToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomFilter filter = new CustomFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}