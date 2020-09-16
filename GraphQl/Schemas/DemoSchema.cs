using Graph_Ql.Queries;
using GraphQL;
using GraphQL.Types;

namespace Graph_Ql.Schemas
{
    public class DemoSchema : Schema
    {
        public DemoSchema(IDependencyResolver  resolver) : base(resolver)
        {
            Query = resolver.Resolve<CustomerQuery>();
        }
    }
}
