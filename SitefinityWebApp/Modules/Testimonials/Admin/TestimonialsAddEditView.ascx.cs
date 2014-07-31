using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.Modules.Testimonials.Admin
{
	public partial class TestimonialsAddEditView : System.Web.UI.UserControl
	{
        private const string UrlNameCharsToReplace = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        private const string UrlNameReplaceString = "-";
		private TestimonialsContext context = TestimonialsContext.Get();

		#region Check Mode

		public enum AdminControlMode
		{
			Create,
			Edit
		}

		/// <summary>
		/// Gets or sets the mode in which to render the control.
		/// </summary>
		/// <value>
		/// The mode.
		/// </value>
		public AdminControlMode Mode 
        { 
            get { return this.mode; } 
            set { this.mode = value; } 
        }

		private AdminControlMode mode;

		private Guid testimonialID = Guid.Empty;

		/// <summary>
		/// Gets the testimonial ID to load in Edit Mode.
		/// </summary>
		protected Guid TestimonialID
		{
			get
			{
				if (this.testimonialID == Guid.Empty)
				{
					// ensure parameter is valid
					var param = Request.RequestContext.RouteData.Values["Params"] as string[];
					if (param == null) return Guid.Empty;

					// grab id from url
					Guid id;
					if (!Guid.TryParse(param[0], out id)) return Guid.Empty;

					// retrieve testimonial
					var testimonial = this.context.Testimonials.FirstOrDefault(t => t.Id == id);
					this.testimonialID = (testimonial == null) ? Guid.Empty : testimonial.Id;
				}

				return this.testimonialID;
			}
		}

		#endregion

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			if (this.IsPostBack || this.Mode != AdminControlMode.Edit) return;

			// retrieve testimonial from DB
			var testimonial = this.context.Testimonials.Where(t => t.Id == this.TestimonialID).FirstOrDefault();
			if (testimonial == null) return;

			// show details for editing
			Name.Text = testimonial.Name;
			Summary.Text = testimonial.Summary;
			Text.Value = testimonial.Text;
			Rating.Value = testimonial.Rating;
			Published.Checked = testimonial.Published;
		}

		/// <summary>
		/// Handles the Click event of the btnSave control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void BtnSave_Click(object sender, EventArgs e)
		{
			switch (this.Mode)
			{
				case AdminControlMode.Edit:

					// update existing testimonial
					var testimonial = this.context.Testimonials.Where(t => t.Id == this.TestimonialID).FirstOrDefault();
					if (testimonial == null) return; // default 404 response

					// mark route handled/found
					RouteHelper.SetUrlParametersResolved();

					testimonial.Name = Name.Text;
                    testimonial.UrlName = Regex.Replace(Name.Text.ToLower(), UrlNameCharsToReplace, UrlNameReplaceString);
					testimonial.Summary = Summary.Text;
					testimonial.Text = Text.Value.ToString();
					testimonial.Rating = Rating.Value;
					testimonial.Published = Published.Checked;
					break;

				case AdminControlMode.Create:
					// create and save new testimonial
					var newTestimonial = new Testimonial();
					newTestimonial.Name = Name.Text;
                    newTestimonial.UrlName = Regex.Replace(Name.Text.ToLower(), UrlNameCharsToReplace, UrlNameReplaceString);
					newTestimonial.Summary = Summary.Text;
					newTestimonial.Text = Text.Value.ToString();
					newTestimonial.Rating = Rating.Value;
					newTestimonial.Published = Published.Checked;
					this.context.Add(newTestimonial);
					break;
			}

			// save and return to main view
			this.context.SaveChanges();
			Response.Redirect(this.ResolveUrl(SiteMapBase.GetActualCurrentNode().ParentNode.Url));
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			if (this.context != null)
				this.context.Dispose();
		}
	}
}
