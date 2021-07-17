using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{


    /*
       The Behavioral patterns capture ways of expressing the division of operations
       between classes and optimize how the communication should be handled.
     * 
     * 
     * Example of StrategyPattern in CS7. OneShotStitchingExtender
     * ProcessQueueItem
     * DROneShotPreviewStitchingProcessQueueItem - Strategy A
     * DROneShotStitchingCalibrationProcessQueueItem - Strategy B
     * ProcessManager -->  private Queue<ProcessQueueItem> _processReqQueue
     * 
     * Practical example of Strategy Pattern:
     * interface ISortingStrategy
     * public class QuickSort : ISortingStrategy
     * public class MergeSort : ISortingStrategy
     * 
     * 
     * What a beauty! Our ISortingStrategy object would decide which algorithm to call. 
     * The great thing is suppose we realize that one of our algorithm is flawed we simply need to change the 
     * sorting algorithm reference in GetSortingOption method and in doing so we need not to change anything in
     * the client code ( i.e the Program class). We can even decide the algorithm at runtime. 
     * Suppose during the peak hours when the number of railway passengers increase we can have another 
     * customized algorithm (say HugeDataSorting) in place. Based on the number of passengers the 
     * ISortingStrategy object would keep changing the reference to HeapSort or HugeDataSorting.
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            CommutationManager obj = new CommutationManager(null);

            switch (DayOfWeek.Monday)
            { 
                case DayOfWeek.Monday:
                    obj.SetCommunicationStrategy(new BikeCommunicationStrategy());
                    break;

                default:
                    obj.SetCommunicationStrategy(new CarCommunicationStragegy());
                    break;
            
            }
            obj.timeToTravel();
            obj.travel();
            obj.costForTravel();
        }

    }



}
