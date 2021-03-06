﻿// ==============================================================================================================
// Microsoft patterns & practices
// CQRS Journey project
// ==============================================================================================================
// ©2012 Microsoft. All rights reserved. Certain content used with permission from contributors
// http://cqrsjourney.github.com/contributors/members
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance 
// with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software distributed under the License is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and limitations under the License.
// ==============================================================================================================

using System;
using TechTalk.SpecFlow;
using System.Globalization;
using System.Text.RegularExpressions;
using W = WatiN.Core;
using System.Threading;
using Registration.ReadModel;
using System.Linq;
using Xunit;

namespace Conference.Specflow.Steps.Registration.EndToEnd
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"the list of the available Order Items for the CQRS summit 2012 conference with the slug code (.*)")]
        public void GivenTheListOfTheAvailableOrderItemsForTheCQRSSummit2012Conference(string conferenceSlug, Table table)
        {
            // Populate Conference data
            var conferenceInfo = ConferenceHelper.PopulateConfereceData(table, conferenceSlug);

            // Store for later use
            ScenarioContext.Current.Set<ConferenceInfo>(conferenceInfo);

            // Navigate to Registration page
            ScenarioContext.Current.Get<W.Browser>().GoTo(Constants.RegistrationPage(conferenceSlug));
        }

        [Given(@"the selected Order Items")]
        public void GivenTheSelectedOrderItems(Table table)
        {
            var browser = ScenarioContext.Current.Get<W.Browser>(); 
            foreach (var row in table.Rows)
            {
                browser.SelectListInTableRow(row["seat type"], row["quantity"]);
            }
        }

        [Given(@"the Promotional Codes")]
        public void GivenThePromotionalCodes(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the Registrant proceed to make the Reservation")]
        public void GivenTheRegistrantProceedToMakeTheReservation()
        {
            WhenTheRegistrantProceedToMakeTheReservation();
        }

        [Given(@"the Registrant proceed to Checkout:Payment")]
        public void GivenTheRegistrantProceedToCheckoutPayment()
        {
            WhenTheRegistrantProceedToCheckoutPayment();
        }

        [Given(@"the Registrant enter these details")]
        public void GivenTheRegistrantEnterTheseDetails(Table table)
        {
            // Allow some time for the events being processed
            Thread.Sleep(TimeSpan.FromSeconds(4));

            var browser = ScenarioContext.Current.Get<W.Browser>();
            browser.SetInputvalue("FirstName", table.Rows[0]["First name"]);
            browser.SetInputvalue("LastName", table.Rows[0]["Last name"]);
            browser.SetInputvalue("Email", table.Rows[0]["email address"]);
            browser.SetInputvalue("data-val-required", table.Rows[0]["email address"], "Please confirm the e-mail address.");

            ScenarioContext.Current.Add("email", table.Rows[0]["email address"]);
        }

        [Given(@"these Seat Types becomes unavailable before the Registrant make the reservation")]
        public void GivenTheseSeatTypesBecomesUnavailableBeforeTheRegistrantMakeTheReservation(Table table)
        {
            var reservationId = ConferenceHelper.ReserveSeats(ScenarioContext.Current.Get<ConferenceInfo>(), table);
            // Store for revert the reservation after scenario ends
            ScenarioContext.Current.Set<Guid>(reservationId, "reservationId");
        }

        [When(@"the Registrant proceed to make the Reservation")]
        public void WhenTheRegistrantProceedToMakeTheReservation()
        {
            ScenarioContext.Current.Get<W.Browser>().ClickAndWait(Constants.UI.NextStepButtonID, Constants.UI.ReservationSuccessfull);
        }

        [When(@"the Registrant proceed to Checkout:Payment")]
        public void WhenTheRegistrantProceedToCheckoutPayment()
        {
            ScenarioContext.Current.Get<W.Browser>().Click(Constants.UI.NextStepButtonID);
        }

        [Then(@"the Registrant is offered to be waitlisted for these Order Items")]
        public void ThenTheRegistrantIsOfferedToBeWaitlistedForTheseOrderItems(Table table)
        {
            ThenTheReservationIsConfirmedForAllTheSelectedOrderItems();
        }

        [Then(@"the Reservation is confirmed for all the selected Order Items")]
        public void ThenTheReservationIsConfirmedForAllTheSelectedOrderItems()
        {
            Assert.True(ScenarioContext.Current.Get<W.Browser>().SafeContainsText(Constants.UI.ReservationSuccessfull),
                string.Format("The following text was not found on the page: {0}", Constants.UI.ReservationSuccessfull)); 
        }

        [Then(@"the total should read \$(.*)")]
        public void ThenTheTotalShouldRead(int value)
        {
            Assert.True(ScenarioContext.Current.Get<W.Browser>().SafeContainsText(value.ToString()),
                string.Format("The following text was not found on the page: {0}", value)); 
        }

        [Then(@"the message '(.*)' will show up")]
        public void ThenTheMessageWillShowUp(string message)
        {
            Assert.True(ScenarioContext.Current.Get<W.Browser>().SafeContainsText(message),
                string.Format("The following text was not found on the page: {0}", message)); 
        }

        [Then(@"the countdown started")]
        public void ThenTheCountdownStarted()
        {
            var countdown = ScenarioContext.Current.Get<W.Browser>().Div("countdown_time").Text;

            Assert.False(string.IsNullOrWhiteSpace(countdown));
            TimeSpan countdownTime = TimeSpan.ParseExact(countdown, @"mm\:ss", CultureInfo.InvariantCulture);
            Assert.True(countdownTime.Minutes > 0 && countdownTime.Minutes < 15);
        }

        [Then(@"the payment options should be offered for a total of \$(.*)")]
        public void ThenThePaymentOptionsShouldBeOfferedForATotalOf(int value)
        {
            Assert.True(ScenarioContext.Current.Get<W.Browser>().SafeContainsText(value.ToString()),
                string.Format("The following text was not found on the page: {0}", value)); 
        }

        [Then(@"these Order Items should be reserved")]
        public void ThenTheseOrderItemsShouldBeReserved(Table table)
        {
            var browser = ScenarioContext.Current.Get<W.Browser>(); 
            foreach (var row in table.Rows)
            {
                Assert.True(browser.ContainsValueInTableRow(row["seat type"], row["quantity"]), 
                    string.Format("The following text was not found on the page: {0} or {1}", row["seat type"], row["quantity"]));             
            }
        }

        [Then(@"these Order Items should not be reserved")]
        public void ThenTheseOrderItemsShouldNotBeReserved(Table table)
        {
            var browser = ScenarioContext.Current.Get<W.Browser>(); 
            foreach (var row in table.Rows)
            {
                Assert.True(browser.ContainsValueInTableRow(row["seat type"], "0"),
                    string.Format("The following text was not found on the page: {0} or {1}", row["seat type"], "0"));                
            }
        }

        [Then(@"the Order should be created with the following Order Items")]
        public void ThenTheOrderShouldBeCreatedWithTheFollowingOrderItems(Table table)
        {
            var browser = ScenarioContext.Current.Get<W.Browser>();
            string accessCode = browser.FindText(new Regex("[A-Z0-9]{6}"));
            Assert.False(string.IsNullOrWhiteSpace(accessCode));

            Thread.Sleep(Constants.WaitTimeout); // Wait for event processing

            var email = ScenarioContext.Current.Get<string>("email");

            // Navigate to Registration page
            browser.GoTo(Constants.FindOrderPage(ScenarioContext.Current.Get<ConferenceInfo>().Slug));
            browser.SetInputvalue("name", email, "email");
            browser.SetInputvalue("name", accessCode, "accessCode");
            browser.Click("find");
            ScenarioContext.Current.Get<W.Browser>().WaitUntilContainsText(Constants.UI.FindOrderSuccessfull, Constants.UI.WaitTimeout.Seconds);

            Assert.True(browser.SafeContainsText(accessCode),
                   string.Format("The following text was not found on the page: {0}", accessCode));
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            // Restore the available setes previous to the reservation
            Guid reservationId;
            if (ScenarioContext.Current.TryGetValue<Guid>("reservationId", out reservationId))
            {
                ConferenceHelper.CancelSeatReservation(ScenarioContext.Current.Get<ConferenceInfo>().Id, reservationId);
            }
        }
    }
}
