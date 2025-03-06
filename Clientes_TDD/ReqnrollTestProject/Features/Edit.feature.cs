﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ReqnrollTestProject.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class EditFeature : object, Xunit.IClassFixture<EditFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Edit", "Proceso de realizar Testing BDD en Editar Cliente con datos válidos e inválidos", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Edit.feature"
#line hidden
        
        public EditFeature(EditFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Editar Cliente con datos válidos")]
        [Xunit.TraitAttribute("FeatureTitle", "Edit")]
        [Xunit.TraitAttribute("Description", "Editar Cliente con datos válidos")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task EditarClienteConDatosValidos()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Editar Cliente con datos válidos", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table6 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table6.AddRow(new string[] {
                            "1753026721",
                            "Reinoso Torres",
                            "Dylan Gabriel",
                            "06/05/2001",
                            "dgreinoso32@gmail.com",
                            "969048289",
                            "Quito",
                            "1"});
#line 7
    await testRunner.GivenAsync("Existe un cliente registrado en la BDD para edicion", ((string)(null)), table6, "Given ");
#line hidden
                global::Reqnroll.Table table7 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table7.AddRow(new string[] {
                            "1753026721",
                            "Reinoso Torres",
                            "Dylan Gabriel",
                            "06/05/2001",
                            "dgreinoso32@gmail.com",
                            "969048289",
                            "Guayaquil",
                            "1"});
#line 10
    await testRunner.WhenAsync("Modifico los datos del cliente en el formulario con datos válidos", ((string)(null)), table7, "When ");
#line hidden
                global::Reqnroll.Table table8 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table8.AddRow(new string[] {
                            "1753026721",
                            "Reinoso Torres",
                            "Dylan Gabriel",
                            "06/05/2001",
                            "dgreinoso32@gmail.com",
                            "969048289",
                            "Guayaquil",
                            "1"});
#line 13
    await testRunner.ThenAsync("El resultado de la actualización en la BDD debe ser", ((string)(null)), table8, "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Editar Cliente con datos inválidos (Cédula vacía)")]
        [Xunit.TraitAttribute("FeatureTitle", "Edit")]
        [Xunit.TraitAttribute("Description", "Editar Cliente con datos inválidos (Cédula vacía)")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task EditarClienteConDatosInvalidosCedulaVacia()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Editar Cliente con datos inválidos (Cédula vacía)", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table9 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table9.AddRow(new string[] {
                            "1753026721",
                            "Reinoso Torres",
                            "Dylan Gabriel",
                            "06/05/2001",
                            "dgreinoso32@gmail.com",
                            "969048289",
                            "Quito",
                            "1"});
#line 19
    await testRunner.GivenAsync("Existe un cliente registrado en la BDD para edicion", ((string)(null)), table9, "Given ");
#line hidden
                global::Reqnroll.Table table10 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table10.AddRow(new string[] {
                            "",
                            "Reinoso Torres",
                            "Dylan Gabriel",
                            "06/05/2001",
                            "dgreinoso32@gmail.com",
                            "969048289",
                            "Guayaquil",
                            "1"});
#line 22
    await testRunner.WhenAsync("Modifico los datos del cliente en el formulario con datos inválidos", ((string)(null)), table10, "When ");
#line hidden
#line 25
    await testRunner.ThenAsync("Debe mostrar un mensaje de error indicando que la cédula es requerida", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Editar Cliente con datos inválidos (Correo inválido)")]
        [Xunit.TraitAttribute("FeatureTitle", "Edit")]
        [Xunit.TraitAttribute("Description", "Editar Cliente con datos inválidos (Correo inválido)")]
        [Xunit.TraitAttribute("Category", "tag1")]
        public async System.Threading.Tasks.Task EditarClienteConDatosInvalidosCorreoInvalido()
        {
            string[] tagsOfScenario = new string[] {
                    "tag1"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Editar Cliente con datos inválidos (Correo inválido)", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table11 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table11.AddRow(new string[] {
                            "1753026721",
                            "Reinoso Torres",
                            "Dylan Gabriel",
                            "06/05/2001",
                            "dgreinoso32@gmail.com",
                            "969048289",
                            "Quito",
                            "1"});
#line 29
    await testRunner.GivenAsync("Existe un cliente registrado en la BDD para edicion", ((string)(null)), table11, "Given ");
#line hidden
                global::Reqnroll.Table table12 = new global::Reqnroll.Table(new string[] {
                            "Cedula",
                            "Apellidos",
                            "Nombres",
                            "FechaNacimiento",
                            "Mail",
                            "Telefono",
                            "Direccion",
                            "Estado"});
                table12.AddRow(new string[] {
                            "1753026721",
                            "Reinoso Torres",
                            "Dylan Gabriel",
                            "06/05/2001",
                            "correoinvalido",
                            "969048289",
                            "Guayaquil",
                            "1"});
#line 32
    await testRunner.WhenAsync("Modifico los datos del cliente en el formulario con datos inválidos", ((string)(null)), table12, "When ");
#line hidden
#line 35
    await testRunner.ThenAsync("Debe mostrar un mensaje de error indicando que el correo es inválido", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await EditFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await EditFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
