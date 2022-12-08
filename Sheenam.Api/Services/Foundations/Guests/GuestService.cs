﻿//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//==================================================

using System;
using System.Threading.Tasks;
using Sheenam.Api.Brokers.Loggings;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(IStorageBroker storageBroker,
                            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            try
            {
                if (guest is null)
                {
                    throw new NullGuestException();
                }

                return await this.storageBroker.InsertGuestAsync(guest);
            }
            catch(NullGuestException nullGuestException)
            {
                var guestValidationException =
                    new GuestValidationException(nullGuestException);

                this.loggingBroker.LogError(guestValidationException);

                throw guestValidationException;
            }
        }
    }
}