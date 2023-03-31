using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Design;

namespace AikidoSystem.UI
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public class ComboBox_M : UserControl
    {
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;
        
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;
        
        public new Color BackColor
        {
            get => backColor;
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
               
            }
        }
        public Color IconColor
        {
            get => iconColor;
            set
            {
                iconColor = value;
                btnIcon.Invalidate();
            }
        }
        public Color ListBackColor
        {
            get => listBackColor;
            set {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }
        public Color ListTextColor
        {
            get => listTextColor;
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }
        public Color BorderColor
        {
            get => borderColor;
            set {
                borderColor = value;
                base.BackColor = borderColor;
            }
        }
        public int BorderSize
        {
            get => borderSize;
            set {
                borderSize = value;
                this.Padding = new Padding(BorderSize);
                AdjustComboBoxDimentions();
            }
        }
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value;
            }
        }

        public string Texts
        {
            get => lblText.Text;
            set => lblText.Text = value;
        }

        public ComboBoxStyle DropDownStyle
        {
            get => cmbList.DropDownStyle;
            set 
            {
                if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
                    cmbList.DropDownStyle = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get => cmbList.Items;
        }

       
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        
        public new object DataSource
        {
            get=>cmbList.DataSource;
            set=>cmbList.DataSource = value;
        }

        [DefaultValue(AutoCompleteMode.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get => cmbList.AutoCompleteMode;
            set => cmbList.AutoCompleteMode = value;
        }

        [DefaultValue(AutoCompleteSource.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get=> cmbList.AutoCompleteSource;
            set=> cmbList.AutoCompleteSource=value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get => cmbList.AutoCompleteCustomSource;
            set => cmbList.AutoCompleteCustomSource = value;
        }

        [Browsable(false)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get=>cmbList.SelectedItem;
            set=>cmbList.SelectedItem = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public int SelectedIndex
        {
            get => cmbList.SelectedIndex;
            set =>cmbList.SelectedIndex = value;
        }

        [DefaultValue("")]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]        
        public string DisplayMember
        {
            get
            {
                return cmbList.DisplayMember;
            }
            set
            {
                cmbList.DisplayMember = value;
                
            }
        }
        
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]        
        public string ValueMember
        {
            get
            {
                return cmbList.ValueMember;
            }
            set
            {
                cmbList.ValueMember = value;
                
            }
        }
    
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]     
        [Bindable(true)]
        public object SelectedValue
        {
            get
            {
                return cmbList.SelectedValue;
            }
            set
            {
                cmbList.SelectedValue = value;
            }
        }
        public event EventHandler OnSelectedIndexChanged;

        

        public ComboBox_M()
        {

            cmbList = new ComboBox();            
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();

            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(this.Font.Name,10F);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(Combobox_SelectedIndexChanged);
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);

            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);

            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8,0,0,0);
            lblText.Font = new Font(this.Font.Name,10F);
            lblText.Click += new EventHandler(Surface_Click);

            this.Controls.Add(lblText);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList);
            this.MinimumSize = new Size(200,30);
            this.Size = new Size(200,30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);
            this.BackColor = borderColor;
            this.ResumeLayout();
            AdjustComboBoxDimentions();
        }

        private void AdjustComboBoxDimentions()
        {
            cmbList.Width = lblText.Width;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblText.Bottom - cmbList.Height
            };

        }

        private void Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged.Invoke(sender, e);
            lblText.Text = cmbList.Text;
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true;
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            Graphics graph = e.Graphics;
            
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X+(iconWidth/2),rectIcon.Bottom,rectIcon.Right,rectIcon.Y);
                graph.DrawPath(pen,path);
            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblText.Text = cmbList.Text;    
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimentions();
        }

    }
}
