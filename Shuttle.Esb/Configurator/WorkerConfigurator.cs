﻿using Shuttle.Core.Infrastructure;

namespace Shuttle.Esb
{
	public class WorkerConfigurator : IConfigurator
	{
		public void Apply(IServiceBusConfiguration configuration)
		{
			Guard.AgainstNull(configuration, "configuration");

			if (ServiceBusConfiguration.ServiceBusSection == null
			    ||
			    ServiceBusConfiguration.ServiceBusSection.Worker == null
			    ||
			    string.IsNullOrEmpty(ServiceBusConfiguration.ServiceBusSection.Worker.DistributorControlWorkQueueUri))
			{
				return;
			}

			configuration.Worker =
				new WorkerConfiguration(configuration.QueueManager.CreateQueue(
					ServiceBusConfiguration.ServiceBusSection.Worker.DistributorControlWorkQueueUri),
					ServiceBusConfiguration.ServiceBusSection.Worker.ThreadAvailableNotificationIntervalSeconds);
		}
	}
}