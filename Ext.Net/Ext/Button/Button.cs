/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.0.0.beta - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-03-07
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Create simple buttons with this component. Customisations include aligned icons, dropdown menus, tooltips and sizing options. Specify a handler to run code when a user clicks the button, or use listeners for other events such as mouseover. 
    /// 
    /// A useful option of Button is the scale configuration. This configuration has three different options:
    /// 'small'
    /// 'medium'
    /// 'large'
    /// 
    /// Buttons can also be toggled. To enable this, you simple set the enableToggle property to true. 
    /// 
    /// You can assign a menu to a button by using the menu configuration. This standard configuration can either be a reference to a menu object, a menu id or a menu config blob. When assigning a menu to a button, an arrow is automatically added to the button. You can change the alignment of the arrow using the arrowAlign configuration on button.
    /// 
    /// Using listeners, you can easily listen to events fired by any component, using the listeners configuration or using the addListener method. Button has a variety of different listeners:
    /// 
    /// click
    /// toggle
    /// mouseover
    /// mouseout
    /// mouseshow
    /// menuhide
    /// menutriggerover
    /// menutriggerout
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Button runat=\"server\" Text=\"Submit\" />")]
    [ToolboxBitmap(typeof(Button), "Build.ToolboxIcons.Button.bmp")]
    [DefaultEvent("DirectClick")]
    [DefaultProperty("Text")]
    [Description("Simple Button class")]
    public partial class Button : ButtonBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Button() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        [Description("")]
        public Button(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="handler"></param>
        [Description("")]
        public Button(string text, string handler)
        {
            this.Text = text;
            this.OnClientClick = handler;
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "button";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.button.Button";
            }
        }

        private ButtonListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public ButtonListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ButtonListeners();
                }

                return this.listeners;
            }
        }


        private ButtonDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side DirectEventHandlers")]
        public ButtonDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ButtonDirectEvents(this);
                }

                return this.directEvents;
            }
        }


        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectClick
        {
            add
            {
                this.DirectEvents.Click.Event += value;
            }
            remove
            {
                this.DirectEvents.Click.Event -= value;
            }
        }
    }
}