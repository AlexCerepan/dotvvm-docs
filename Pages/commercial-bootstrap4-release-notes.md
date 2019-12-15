# Release notes
## 2.3.1

* **Package updates**
    * Dotvvm upgraded to **2.3.1**

* **Changes to existing controls**
    * **Tooltip** and **Popover**
        * Added *AutoCloseMonitoringDepth* property which allows to set how many levels of ancestors would be monitored for element removal. 
        Detecting removal of **Tooltip** | **Popover** source element or its parents would close **Tooltip** | **Popover**.
## 2.3.0

* **Package updates**
    * Dotvvm upgraded to **2.3.0**

* **Changes to existing controls**
    * **CheckBox**
        * Added *RenderLabel* property which allows user to set whether checkbox should render label.  
        When not set than label will be rendered only if needed.
    * **RadioButton**
        * Added *RenderLabel* property which allows user to set whether checkbox should render label.  
        When not set than label will be rendered only if needed.
* **Other changes**
    * Users can now specify their own IResource to be used as BoostrapJs, BootstrapCss and JQuery.  
    [```Usage example```](https://www.dotvvm.com/docs/tutorials/commercial-bootstrap4-for-dotvvm/)
    
## 2.2.0

* **Package updates**
    * Dotvvm upgraded to **2.2.0**

* **Bug fixes**
    * BootstrapItemsControl     
        *Base for most controls with DataSource*
        * Data context is now correctly set for child controls.
    * GridView
        * All HTML attributes are now present on correct element when *MaximumScreenSizeBeforeScrollBarShows* is set to *None*
    * other small bug fixes
    


## 2.1.0
### First stable ( non-preview ) release.

* **Package updates**
    * Dotvvm upgraded to **2.1.0**
    * Bootstrap upgraded to **4.3.1**

* **New controls**
    * [```Spinner```](https://www.dotvvm.com/docs/controls/bootstrap4/Spinner)
    * [```Toast```](https://www.dotvvm.com/docs/controls/bootstrap4/Toast)

* **Changes to existing controls**
    * **Carousel**
        * Added *ImageAlternateTextBinding* property
    * **CheckBox**
        * **BREAKING CHANGE** : enum *BootstrapFormStyle* used in *FormControlStyle* property renamed to *CheckBoxStyle*
    * **CheckBoxFormGroup**
        * **BREAKING CHANGE** : enum *BootstrapFormStyle* used in *FormControlStyle* property renamed to *CheckBoxStyle*
    * **GridView**
        * Added *Border* property
        * Added *Caption* property
        * **BREAKING CHANGE** : Boolean *IsResponsive* property was replaced by *MaximumScreenSizeBeforeScrollBarShows* enum
    * **ListGroup**
        * Added *Type* property
        * Added *MaximumScreenSizeBeforeChangeToVertical* property
    * **ModalDialog**
        * Added *ScrollableContent* property
        * Added new XL *Size*
    * **Popover**
        * Added *AllowHtmlSanitization* property
    * **ResponsiveNavigation**
        * **BREAKING CHANGE** : enum *ResponsiveNavigationBreakpoins* used in *MaximumScreenSizeBeforeCollapse* property was renamed to *ResponsiveBreakpoints*
    * **Tooltip**
        * Added *AllowHtmlSanitization* propery
        
## 2.0.0-preview02-final
* **New controls**
  * [```CollapsiblePanel```](https://www.dotvvm.com/docs/controls/bootstrap4/CollapsiblePanel)
  * [```ComboBoxFormGroup```](https://www.dotvvm.com/docs/controls/bootstrap4/ComboBoxFormGroup)
  * [```DateTimePickerFormGroup```](https://www.dotvvm.com/docs/controls/bootstrap4/DateTimePickerFormGroup)
  * [```RadioButtonFormGroup```](https://www.dotvvm.com/docs/controls/bootstrap4/RadioButtonFormGroup)
  * [```TextBoxFormGroup```](https://www.dotvvm.com/docs/controls/bootstrap4/TextBoxFormGroup)

* **Changes to existing controls**
    * Every items control (```Accordion```, ```NavigationBar```, etc.) now accepts any child control which implements given interface instead of one concrete implementation (```IAccordionItem``` instead of ```AccordionItem```).

## 2.0.0-preview01-final
* First release of Bootstrap 4 controls