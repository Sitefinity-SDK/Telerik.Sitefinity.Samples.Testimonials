using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Web;
using Telerik.Web.UI;

namespace SitefinityWebApp.Modules.Testimonials.Admin
{
	public partial class TestimonialsAdminView : System.Web.UI.UserControl
	{
		private TestimonialsContext context = TestimonialsContext.Get();

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			// update "Edit" hyperlink column
			var linkColumn = TestimonialsGrid.MasterTableView.Columns.FindByUniqueName("ID") as GridHyperLinkColumn;
			linkColumn.DataNavigateUrlFormatString = string.Concat(this.ResolveUrl(SiteMapBase.GetActualCurrentNode().Url), "/Edit/{0}");

			// retrieve and bind testimonials
			TestimonialsGrid.DataSource = this.context.Testimonials;
			TestimonialsGrid.DataBind();
		}

		/// <summary>
		/// Handles the DeleteCommand event of the TestimonialsGrid control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs"/> instance containing the event data.</param>
		protected void TestimonialsGrid_DeleteCommand(object sender, GridCommandEventArgs e)
		{
			// check for parameter
			if (e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"] == null) return;

			// get ID from parameter
			Guid id;
			if (!Guid.TryParse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString(), out id)) return;

			// retrieve testimonial
			var item = this.context.Testimonials.FirstOrDefault(t => t.Id == id);
			if (item == null) return;

			// delete item
			this.context.Delete(item);
			this.context.SaveChanges();

			// retrieve and bind testimonials
			TestimonialsGrid.DataSource = this.context.Testimonials;
			TestimonialsGrid.DataBind();
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			if (this.context != null)
				this.context.Dispose();
		}
	}
}
