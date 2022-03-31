using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlecKinler.AdventureGame.WinHost
{
    public partial class CharacterForm : Form
    {
        public CharacterForm()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); //base keyword prevents a recursive function (that shit would crash)

            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _txtDescription.Text = Character.Description;
                _ddlRace.Text = Character.Race;
                _ddlProfession.Text = Character.Profession;
                _txtStrength.Text = Character.Strength.ToString();
                _txtIntellect.Text = Character.Intellect.ToString();
                _txtCharisma.Text = Character.Charisma.ToString();
                _txtAgility.Text = Character.Agility.ToString();
                _txtConstitution.Text = Character.Constitution.ToString();
            };
        }

        private int ReadAsInt32(Control control, int defaultValue)
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return defaultValue;
        }
        private void OnSave(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            var character = new Character();

            character.Name = _txtName.Text;
            character.Description = _txtDescription.Text;
            character.Race = _ddlRace.Text;
            character.Profession = _ddlProfession.Text;
            character.Strength = ReadAsInt32(_txtStrength, -1);
            character.Intellect = ReadAsInt32(_txtIntellect, -1);
            character.Charisma = ReadAsInt32(_txtCharisma, -1);
            character.Agility = ReadAsInt32(_txtAgility, -1);
            character.Constitution = ReadAsInt32(_txtConstitution, -1);

            //validate; close if valid
            var error = character.Validate();
            if (String.IsNullOrEmpty(error))
            {
                //valid
                Character = character;
                DialogResult = DialogResult.OK;
                Close();
                return;
            };
            //display error
            MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnValidateName(object sender, CancelEventArgs e)
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }

        private void CharacterForm_Load(object sender, EventArgs e)
        {

        }

    }
}
