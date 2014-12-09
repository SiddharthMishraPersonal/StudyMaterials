namespace ObserverPattern
{
  /// <summary>
  /// This interface will keep a list of all invest0rs and will contain methods to add and remove investors.
  /// The interface will also have a method to notify all investors about the price change.
  /// </summary>
  public interface IStock
  {
    double Price { get; set; }
    string Symbol { get; }


    void RegisterInvestor(IInvestor investor);
    void RemoveInvestor(IInvestor investor);
    void NotifyInvestor();
  }
}
