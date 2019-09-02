import java.util.Scanner;

public class ChristmasPreparation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int paper = Integer.parseInt(scanner.nextLine());
        int cloth = Integer.parseInt(scanner.nextLine());
        double glue = Double.parseDouble(scanner.nextLine());
        int namalenie = Integer.parseInt(scanner.nextLine());

        double allPaper = (paper* 1.0) * 5.80;
        double allCloth = (cloth* 1.0) * 7.20;
        double allGlue = glue * 1.20;

        double allProduct = (allCloth + allGlue + allPaper);
        double total = allProduct - (allProduct * namalenie/100);

        System.out.printf("%.3f", total);
    }
}
