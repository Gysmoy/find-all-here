using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Android.App;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Find All Here")]
[assembly: AssemblyDescription("Aplicación de compra y venta de productos de Segunda Mano")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Software Development Perú")]
[assembly: AssemblyProduct("Find All Here")]
[assembly: AssemblyCopyright("© Todos los derechos reservados")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyVersion("2022.1.0.0")]
[assembly: AssemblyFileVersion("2022.1.0.0")]

// Add some common permissions, these can be removed if not needed
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]
