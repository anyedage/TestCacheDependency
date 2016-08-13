using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCacheDependency.Entities;

namespace TestCacheDependency
{
    public class EventPublisher
    {
        public void Publish<T>(EventEntity<T> eventEntity) where T : class
        {
//            var consumers = DependencyResolver.GetDeleteServices<T>();
//            foreach (IConsumer<EntityDeleted<T>> consumer in consumers)
//            {
//                this.PublishToConsumer(consumer, eventEntity);
//            }
        }

//        protected virtual void PublishToConsumer<T>(IConsumer<T> consumer, T eventMessage)
//        {
//            try
//            {
//                consumer.HandleEvent(eventMessage);
//            }
//            catch (Exception exception)
//            {
//                throw;
//            }
//        }
    }
}
