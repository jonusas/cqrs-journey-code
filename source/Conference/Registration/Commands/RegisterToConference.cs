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

namespace Registration.Commands
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class RegisterToConference : ICommand
    {
        public class Ticket
        {
            public Guid TicketTypeId { get; set; }

            public int Quantity { get; set; }
        }

        public Guid Id { get; private set; }

        public Guid RegistrationId { get; set; }

        public Guid ConferenceId { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}