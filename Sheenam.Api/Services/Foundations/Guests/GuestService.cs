﻿//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//==================================================

using System;
using System.Threading.Tasks;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Services.Foundations.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            Guest returningGuest = await this.storageBroker.InsertGuestAsync(guest);

            returningGuest.FirstName = "Abdumajid";

            return returningGuest;
        }
    }
}