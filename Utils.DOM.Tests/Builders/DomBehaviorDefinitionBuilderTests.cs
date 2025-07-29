﻿namespace Skyline.DataMiner.Utils.DOM.Tests.Builders
{
	using System;

	using FluentAssertions;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
	using Skyline.DataMiner.Net.Apps.DataMinerObjectModel.Status;
	using Skyline.DataMiner.Utils.DOM.Builders;

	[TestClass]
	public class DomBehaviorDefinitionBuilderTests
	{
		[TestMethod]
		public void DomBehaviorDefinitionBuilder_WithID()
		{
			var id = new DomBehaviorDefinitionId(Guid.NewGuid());

			var definition = new DomBehaviorDefinitionBuilder()
				.WithID(id)
				.Build();

			definition.ID.Should().Be(id);
		}

		[TestMethod]
		public void DomBehaviorDefinitionBuilder_WithName()
		{
			var name = "My name";

			var definition = new DomBehaviorDefinitionBuilder()
				.WithName(name)
				.Build();

			definition.Name.Should().Be(name);
		}

		[TestMethod]
		public void DomBehaviorDefinitionBuilder_WithInitialStatusId()
		{
			var initialStatus = "draft";

			var definition = new DomBehaviorDefinitionBuilder()
				.WithInitialStatusId(initialStatus)
				.Build();

			definition.InitialStatusId.Should().Be(initialStatus);
		}

		[TestMethod]
		public void DomBehaviorDefinitionBuilder_WithStatuses()
		{
			var statuses = new[]
			{
				new DomStatus("draft", "Draft"),
				new DomStatus("confirmed", "Confirmed"),
			};

			var definition = new DomBehaviorDefinitionBuilder()
				.WithStatuses(statuses)
				.Build();

			definition.Statuses.Should().BeEquivalentTo(statuses);
		}

		[TestMethod]
		public void DomBehaviorDefinitionBuilder_WithStatusTransitions()
		{
			var statusDraft = new DomStatus("draft", "Draft");
			var statusConfirmed = new DomStatus("confirmed", "Confirmed");
			var statusRunning = new DomStatus("running", "Running");

			var transitions = new[]
			{
				new DomStatusTransition("draft_to_confirmed", statusDraft.Id, statusConfirmed.Id),
				new DomStatusTransition("confirmed_to_running", statusConfirmed.Id, statusRunning.Id),
			};

			var definition = new DomBehaviorDefinitionBuilder()
				.WithStatusTransitions(transitions)
				.Build();

			definition.StatusTransitions.Should().BeEquivalentTo(transitions);
		}
	}
}
