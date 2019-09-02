import java.util.Scanner;

public class Shivashki_Ceh {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int tableCount = Integer.parseInt(scanner.nextLine());
        double tableLneght = Double.parseDouble(scanner.nextLine());
        double tableWidth = Double.parseDouble(scanner.nextLine());

        double coverPriceUSD = 7.0;
        double diamondPriceUSD = 9.0;
        double usdTObgn = 1.85;

        double allCoverArea = tableCount * (tableLneght + 2 *0.3) * (tableWidth + 2 * 0.3);
        double allDiamondArea = tableCount + (tableLneght / 2) * (tableLneght / 2);

        double allProductPriceUSD = allCoverArea * coverPriceUSD + allDiamondArea * diamondPriceUSD;
        double allProductPriceBGN = allProductPriceUSD * usdTObgn;

        System.out.printf("%.2f USD%n%.2f BGN", allProductPriceUSD,allProductPriceBGN);

    }
}
