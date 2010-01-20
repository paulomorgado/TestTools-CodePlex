//-----------------------------------------------------------------------
// <copyright file="CommonAssemblyInfo.cs"
//            solution="PMTestTools"
//            company="Paulo Morgado">
//     Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <author>Paulo Morgado</author>
// <summary>>Common assembly information.</summary>
//-----------------------------------------------------------------------

using System;
using System.Reflection;

[assembly: CLSCompliant(true)]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyProduct("PauloMorgado.TestTools")]
[assembly: AssemblyCompany("Paulo Morgado")]
[assembly: AssemblyCopyright("Copyright © Paulo Morgado 2010")]
[assembly: AssemblyTrademark("Paulo Morgado")]
[assembly: AssemblyCulture("")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("3.5.*")]
////[assembly: AssemblyFileVersion("1.0.0.0")]
