using MetroFramework.Forms;

namespace VersionUpdater.Net.Helpers.Forms
{
    /// <summary>
    /// If there is an update, the form that will appear.
    /// </summary>
    public partial class UpdateMessageForm : MetroForm
    {
        /// <summary>
        /// Constructor of <see cref="UpdateMessageForm"/>.
        /// </summary>
        public UpdateMessageForm()
        {
            InitializeComponent();

            this.ControlBox = false;
            this.Resizable = false;
        }
    }
}
