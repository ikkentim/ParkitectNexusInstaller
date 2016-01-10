
// This file has been generated by the GUI designer. Do not modify.
namespace ParkitectNexus.Client.Linux
{
	public partial class ModInstallDialog
	{
		private global::Gtk.VBox dialog1_VBox1;
		
		private global::Gtk.Alignment alignment3;
		
		private global::Gtk.Label lblModName;
		
		private global::Gtk.Alignment alignment1;
		
		private global::Gtk.ProgressBar installProgress;
		
		private global::Gtk.Alignment alignment2;
		
		private global::Gtk.Label lblProgressLabel;
		
		private global::Gtk.Button btnFinished;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ParkitectNexus.Client.Linux.ModInstallDialog
			this.Name = "ParkitectNexus.Client.Linux.ModInstallDialog";
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("ParkitectNexus.Client.Linux.parkitectnexus_logo.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child ParkitectNexus.Client.Linux.ModInstallDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.dialog1_VBox1 = new global::Gtk.VBox ();
			this.dialog1_VBox1.Name = "dialog1_VBox1";
			this.dialog1_VBox1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox1.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment3.Name = "alignment3";
			this.alignment3.LeftPadding = ((uint)(20));
			this.alignment3.TopPadding = ((uint)(30));
			this.alignment3.RightPadding = ((uint)(20));
			this.alignment3.BottomPadding = ((uint)(20));
			// Container child alignment3.Gtk.Container+ContainerChild
			this.lblModName = new global::Gtk.Label ();
			this.lblModName.Name = "lblModName";
			this.lblModName.Xalign = 0F;
			this.lblModName.LabelProp = global::Mono.Unix.Catalog.GetString ("label2");
			this.alignment3.Add (this.lblModName);
			this.dialog1_VBox1.Add (this.alignment3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.dialog1_VBox1 [this.alignment3]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child dialog1_VBox1.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(10));
			this.alignment1.RightPadding = ((uint)(10));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.installProgress = new global::Gtk.ProgressBar ();
			this.installProgress.Name = "installProgress";
			this.alignment1.Add (this.installProgress);
			this.dialog1_VBox1.Add (this.alignment1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.dialog1_VBox1 [this.alignment1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child dialog1_VBox1.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment (0F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.LeftPadding = ((uint)(20));
			this.alignment2.TopPadding = ((uint)(10));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.lblProgressLabel = new global::Gtk.Label ();
			this.lblProgressLabel.Name = "lblProgressLabel";
			this.lblProgressLabel.Xalign = 0F;
			this.lblProgressLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("label1");
			this.alignment2.Add (this.lblProgressLabel);
			this.dialog1_VBox1.Add (this.alignment2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.dialog1_VBox1 [this.alignment2]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			w1.Add (this.dialog1_VBox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(w1 [this.dialog1_VBox1]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Internal child ParkitectNexus.Client.Linux.ModInstallDialog.ActionArea
			global::Gtk.HButtonBox w9 = this.ActionArea;
			w9.Name = "dialog1_ActionArea";
			w9.Spacing = 10;
			w9.BorderWidth = ((uint)(5));
			w9.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnFinished = new global::Gtk.Button ();
			this.btnFinished.CanDefault = true;
			this.btnFinished.CanFocus = true;
			this.btnFinished.Name = "btnFinished";
			this.btnFinished.UseUnderline = true;
			this.btnFinished.Label = global::Mono.Unix.Catalog.GetString ("Finish");
			global::Gtk.Image w10 = new global::Gtk.Image ();
			w10.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.btnFinished.Image = w10;
			this.AddActionWidget (this.btnFinished, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w11 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w9 [this.btnFinished]));
			w11.Expand = false;
			w11.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 156;
			this.Show ();
		}
	}
}
