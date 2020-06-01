public Task<IEnumerable<T>> GetItemsAsync(
    Expression<Func<T, bool>> queryPredicate,
    Expression<Func<T, int>> orderDescendingPredicate,
    int page = 1, int pageSize = 10
)
{
    var result = _items.AsQueryable()
        .Where(queryPredicate) // filter
        .OrderByDescending(orderDescendingPredicate) // sort
        .Skip(page * pageSize) // find page
        .Take(pageSize) // take items
        .AsEnumerable(); // make enumeratable

    return Task<IEnumerable<T>>.FromResult(result);
}