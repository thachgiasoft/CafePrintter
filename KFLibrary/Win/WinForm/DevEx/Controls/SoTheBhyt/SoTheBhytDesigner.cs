//<auto-generated />

using System.ComponentModel.Design;
using System.Security.Permissions;
using System.Windows.Forms.Design;

namespace KFLibrary.Win.WinForm.DevEx.Controls
{
    [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
    internal class SoTheBhytDesigner : ControlDesigner
    {
        /* -------------------------------- Enums ------------------------------------ */
        /* --------------------------------------------------------------------------- */

        /* ------------------------------- Variables --------------------------------- */
        private DesignerActionListCollection _actionLists;
        /* --------------------------------------------------------------------------- */

        /* ------------------------------ Properties --------------------------------- */
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actionLists == null)
                {
                    _actionLists = new DesignerActionListCollection();
                    _actionLists.Add(
                        new SoTheBhytDesignerActionList(this.Component));
                    // Common Designer Action List
                    _actionLists.Add(
                        new CommonDesignerActionList(this.Component));
                }
                return _actionLists;
            }
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.Moveable;
            }
        }
        /* --------------------------------------------------------------------------- */

        /* -------------------------------- Methods ---------------------------------- */
        /* --------------------------------------------------------------------------- */

        /* --------------------------- Event handlers--------------------------------- */
        /* --------------------------------------------------------------------------- */

        /* --------------------------------- Test ------------------------------------ */
        // Method test code
        private void Test()
        {
            // Todo: test code here
        }
        /* --------------------------------------------------------------------------- */
    }
}
