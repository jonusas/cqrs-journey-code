﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.261
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Conference.Specflow.Features.Registration.GroupReservation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class RegistrantScenariosForRegisteringAGroupOfAttendeesForAConferenceWhenAllSeatsAreAvailableInAllTheSeatTypesFeature : Xunit.IUseFixture<RegistrantScenariosForRegisteringAGroupOfAttendeesForAConferenceWhenAllSeatsAreAvailableInAllTheSeatTypesFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GroupRegistrationReservationWithFullAvailability.feature"
#line hidden
        
        public RegistrantScenariosForRegisteringAGroupOfAttendeesForAConferenceWhenAllSeatsAreAvailableInAllTheSeatTypesFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Registrant scenarios for registering a group of Attendees for a conference when a" +
                    "ll Seats are available in all the Seat Types", "In order to register for conference a group of Attendees\r\nAs a Registrant\r\nI want" +
                    " to be able to select Order Items from one or many available Order Items and mak" +
                    "e a Reservation", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 20
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "rate",
                        "quota"});
            table1.AddRow(new string[] {
                        "General admission",
                        "$199",
                        "100"});
            table1.AddRow(new string[] {
                        "CQRS Workshop",
                        "$500",
                        "100"});
            table1.AddRow(new string[] {
                        "Additional cocktail party",
                        "$50",
                        "100"});
#line 21
 testRunner.Given("the list of the available Order Items for the CQRS summit 2012 conference with th" +
                    "e slug code GroupRegFull", ((string)(null)), table1);
#line hidden
        }
        
        public virtual void SetFixture(RegistrantScenariosForRegisteringAGroupOfAttendeesForAConferenceWhenAllSeatsAreAvailableInAllTheSeatTypesFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Registrant scenarios for registering a group of Attendees for a conference when a" +
            "ll Seats are available in all the Seat Types")]
        [Xunit.TraitAttribute("Description", "All the Order Items are available and all get selected, then all get reserved")]
        public virtual void AllTheOrderItemsAreAvailableAndAllGetSelectedThenAllGetReserved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("All the Order Items are available and all get selected, then all get reserved", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 20
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table2.AddRow(new string[] {
                        "General admission",
                        "3"});
            table2.AddRow(new string[] {
                        "CQRS Workshop",
                        "1"});
            table2.AddRow(new string[] {
                        "Additional cocktail party",
                        "2"});
#line 31
 testRunner.Given("the selected Order Items", ((string)(null)), table2);
#line 36
 testRunner.When("the Registrant proceed to make the Reservation");
#line 37
 testRunner.Then("the Reservation is confirmed for all the selected Order Items");
#line 38
 testRunner.And("the total should read $1197");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Registrant scenarios for registering a group of Attendees for a conference when a" +
            "ll Seats are available in all the Seat Types")]
        [Xunit.TraitAttribute("Description", "All the Order Items are available and some get selected, then only the selected g" +
            "et reserved")]
        public virtual void AllTheOrderItemsAreAvailableAndSomeGetSelectedThenOnlyTheSelectedGetReserved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("All the Order Items are available and some get selected, then only the selected g" +
                    "et reserved", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 20
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table3.AddRow(new string[] {
                        "General admission",
                        "2"});
            table3.AddRow(new string[] {
                        "Additional cocktail party",
                        "2"});
#line 45
 testRunner.Given("the selected Order Items", ((string)(null)), table3);
#line 49
 testRunner.When("the Registrant proceed to make the Reservation");
#line 50
 testRunner.Then("the Reservation is confirmed for all the selected Order Items");
#line 51
 testRunner.And("the total should read $498");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Registrant scenarios for registering a group of Attendees for a conference when a" +
            "ll Seats are available in all the Seat Types")]
        [Xunit.TraitAttribute("Description", "All the Order Items are available and all get waitlisted")]
        public virtual void AllTheOrderItemsAreAvailableAndAllGetWaitlisted()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("All the Order Items are available and all get waitlisted", new string[] {
                        "Ignore"});
#line 60
this.ScenarioSetup(scenarioInfo);
#line 20
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table4.AddRow(new string[] {
                        "General admission",
                        "2"});
            table4.AddRow(new string[] {
                        "Additional cocktail party",
                        "2"});
#line 61
 testRunner.Given("the selected Order Items", ((string)(null)), table4);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type"});
            table5.AddRow(new string[] {
                        "General admission"});
            table5.AddRow(new string[] {
                        "Additional cocktail party"});
#line 65
 testRunner.And("these Seat Types becomes unavailable before the Registrant make the reservation", ((string)(null)), table5);
#line 69
 testRunner.When("the Registrant proceed to make the Reservation");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table6.AddRow(new string[] {
                        "General admission",
                        "2"});
            table6.AddRow(new string[] {
                        "Additional cocktail party",
                        "2"});
#line 70
 testRunner.Then("the Registrant is offered to be waitlisted for these Order Items", ((string)(null)), table6);
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute(Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Registrant scenarios for registering a group of Attendees for a conference when a" +
            "ll Seats are available in all the Seat Types")]
        [Xunit.TraitAttribute("Description", "All the Order Items are available, 1 becomes partially available, 1 becomes unava" +
            "ilable and 1 is available,")]
        public virtual void AllTheOrderItemsAreAvailable1BecomesPartiallyAvailable1BecomesUnavailableAnd1IsAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("All the Order Items are available, 1 becomes partially available, 1 becomes unava" +
                    "ilable and 1 is available,", new string[] {
                        "Ignore"});
#line 82
this.ScenarioSetup(scenarioInfo);
#line 20
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table7.AddRow(new string[] {
                        "General admission",
                        "2"});
            table7.AddRow(new string[] {
                        "CQRS Workshop",
                        "1"});
            table7.AddRow(new string[] {
                        "Additional cocktail party",
                        "2"});
#line 84
 testRunner.Given("the selected Order Items", ((string)(null)), table7);
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type"});
            table8.AddRow(new string[] {
                        "General admission"});
#line 89
 testRunner.And("these Seat Types becomes partially unavailable before the Registrant make the res" +
                    "ervation", ((string)(null)), table8);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type"});
            table9.AddRow(new string[] {
                        "Additional cocktail party"});
#line 92
 testRunner.And("these Seat Types becomes unavailable before the Registrant make the reservation", ((string)(null)), table9);
#line 95
 testRunner.When("the Registrant proceed to make the Reservation");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table10.AddRow(new string[] {
                        "General admission",
                        "1"});
            table10.AddRow(new string[] {
                        "Additional cocktail party",
                        "2"});
#line 96
 testRunner.Then("the Registrant is offered to be waitlisted for these Order Items", ((string)(null)), table10);
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "seat type",
                        "quantity"});
            table11.AddRow(new string[] {
                        "General admission",
                        "1"});
            table11.AddRow(new string[] {
                        "CQRS Workshop",
                        "1"});
#line 100
 testRunner.And("These other Order Items get reserved", ((string)(null)), table11);
#line 104
 testRunner.And("the total should read $699");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                RegistrantScenariosForRegisteringAGroupOfAttendeesForAConferenceWhenAllSeatsAreAvailableInAllTheSeatTypesFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RegistrantScenariosForRegisteringAGroupOfAttendeesForAConferenceWhenAllSeatsAreAvailableInAllTheSeatTypesFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
