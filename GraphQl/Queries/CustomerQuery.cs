using Graph_Ql.Persistance;
using Graph_Ql.Types;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph_Ql.Queries
{
    public class CustomerQuery : ObjectGraphType
    {
        private readonly GraphQlDbContext _appContext;
        public CustomerQuery(GraphQlDbContext appContext)
        {
            this._appContext = appContext;
            Name = "Query";
            Field<ListGraphType<CustomerGraphType>>("customers", "Returns a list of Customer", resolve: context => _appContext.Customers.ToList());
            Field<CustomerGraphType>("customer", "Returns a Single Customer",
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Customer Id" }),
                    context => _appContext.Customers.Single(x => x.Id == context.Arguments["id"].GetPropertyValue<int>()));
        }
    }
}
