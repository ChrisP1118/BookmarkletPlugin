﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookmarkletPlugin.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BookmarkletPlugin.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (function () {
        ///    function callback() {
        ///        (function ($) {
        ///            var jQuery = $;
        ///
        ///            if (!document.activeElement) {
        ///                alert(&apos;Click on the username field and then click on the bookmarklet.&apos;);
        ///                return;
        ///            }
        ///
        ///            activeElement = document.activeElement;
        ///            if (activeElement.type.toLowerCase() != &apos;text&apos; &amp;&amp; activeElement.tagName.toLowerCase() != &apos;textarea&apos;) {
        ///                alert(&apos;Click on the username field and then click on [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Bookmarklet {
            get {
                return ResourceManager.GetString("Bookmarklet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;body&gt;
        ///&lt;form method=&quot;get&quot; action=&quot;{action}&quot;&gt;
        ///    &lt;table&gt;
        ///        &lt;tr&gt;
        ///            &lt;td&gt;Bookmarklet Name:&lt;/td&gt;
        ///            &lt;td&gt;&lt;input type=&quot;text&quot; name=&quot;name&quot; value=&quot;Login via KeePass&quot; /&gt;&lt;/td&gt;
        ///            &lt;td&gt;This is the name that will be displayed in your browser&apos;s bookmarks.&lt;/td&gt;
        ///		&lt;/tr&gt;
        ///        &lt;tr&gt;
        ///            &lt;td&gt;Favored User Name:&lt;/td&gt;
        ///            &lt;td&gt;&lt;input type=&quot;text&quot; name=&quot;favoredUsername&quot; value=&quot;webmaster&quot; /&gt;&lt;/td&gt;
        ///            &lt;td&gt;If multiple entries exist for one URL, the one with  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CreateBookmarklet {
            get {
                return ResourceManager.GetString("CreateBookmarklet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;html&gt;
        ///&lt;body&gt;
        ///    &lt;p&gt;The link below is your bookmarklet. Drag it to your bookmark menu, folder, or toolbar.&lt;/p&gt;
        ///    &lt;p&gt;&lt;a href=&quot;{bookmarklet}&quot;&gt;{name}&lt;/a&gt;&lt;/p&gt;
        ///&lt;/body&gt;
        ///&lt;/html&gt;.
        /// </summary>
        internal static string ViewBookmarklet {
            get {
                return ResourceManager.GetString("ViewBookmarklet", resourceCulture);
            }
        }
    }
}