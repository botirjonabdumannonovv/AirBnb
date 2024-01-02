using System.Linq.Expressions;

namespace AirBnb.ServerApp.Persistence.Caching.Models;

/// <summary>
/// Expression visitor to compute hash code for given expression
/// </summary>
public class ExpressionHashCodeVisitor : ExpressionVisitor
{
    public int HashSum { get; private set; } = 17;

    private void Combine(MethodCallExpression methodCallExpression)
    {
        HandlePaginationCall(methodCallExpression);
        HandleFilterCall(methodCallExpression);
    }

    private void HandlePaginationCall(MethodCallExpression methodCallExpression)
    {
        if (methodCallExpression.Method.Name is nameof(Queryable.Skip) or nameof(Queryable.Take))
        {
            HashSum = HashSum * 23 + HashCode.Combine(
                methodCallExpression.NodeType,
                methodCallExpression.Method.Name,
                (methodCallExpression.Arguments[1] as ConstantExpression)!.Value
            );
        }
    }

    private void HandleFilterCall(MethodCallExpression methodCallExpression)
    {
        if (methodCallExpression.Method.Name is nameof(Queryable.Where))
        {
            // TODO : Implement
        }
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        Combine(node);
        foreach (var expression in node.Arguments) Visit(expression);

        return node;
    }
}