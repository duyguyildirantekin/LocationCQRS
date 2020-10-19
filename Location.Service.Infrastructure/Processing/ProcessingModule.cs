﻿using Autofac;
using Location.Service.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Location.Service.Infrastructure.Processing
{
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<DomainEventsDispatcher>()
            //    .As<IDomainEventsDispatcher>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(PaymentCreatedNotification).GetTypeInfo().Assembly)
            //    .AsClosedTypesOf(typeof(IDomainEventNotification<>)).InstancePerDependency();

            //builder.RegisterGenericDecorator(
            //    typeof(DomainEventsDispatcherNotificationHandlerDecorator<>),
            //    typeof(INotificationHandler<>));

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerDecorator<>),
                typeof(ICommandHandler<>));

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
                typeof(ICommandHandler<,>));

            builder.RegisterType<CommandsDispatcher>()
                .As<ICommandsDispatcher>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<CommandsScheduler>()
            //    .As<ICommandsScheduler>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterGenericDecorator(
            //    typeof(LoggingCommandHandlerDecorator<>),
            //    typeof(ICommandHandler<>));

            //builder.RegisterGenericDecorator(
            //    typeof(LoggingCommandHandlerWithResultDecorator<,>),
            //    typeof(ICommandHandler<,>));
        }
    }
}
