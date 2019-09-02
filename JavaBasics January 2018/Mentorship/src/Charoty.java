import java.util.Scanner;

public class Charoty {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int campaignDays = Integer.parseInt(scanner.nextLine());
        int cookCount = Integer.parseInt(scanner.nextLine());
        int cakeCount = Integer.parseInt(scanner.nextLine());
        int waffersCount = Integer.parseInt(scanner.nextLine());
        int pancakesCount = Integer.parseInt(scanner.nextLine());

        double cakePrice = 45.0;
        double wafferPrice = 5.80;
        double pancakePrice = 3.2;
        double expense = 1.0 / 8.0;

        double allCakeMoneyOneDay = cakeCount * cakePrice;
        double allWafferMoneyOneDay = waffersCount * wafferPrice;
        double allpancakeMoneyOneDay = pancakePrice * pancakesCount;

        double allMoneyOneDay = (allCakeMoneyOneDay + allpancakeMoneyOneDay + allWafferMoneyOneDay) * cookCount;
        double allMoneyCampaign = allMoneyOneDay * campaignDays;

        double moneyForCharity = allMoneyCampaign - (allMoneyCampaign * expense);

        System.out.printf("%.2f", moneyForCharity);
    }
}
