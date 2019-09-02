import java.util.Scanner;

public class FlowerShop {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int magnoliiCount = Integer.parseInt(scanner.nextLine());
        int zumbulCount = Integer.parseInt(scanner.nextLine());
        int rosesCount = Integer.parseInt(scanner.nextLine());
        int kaktusCount = Integer.parseInt(scanner.nextLine());
        double presentPrice = Double.parseDouble(scanner.nextLine());

        double magnolii = magnoliiCount * 3.25;
        double zumbul = zumbulCount * 4;
        double roses = rosesCount * 3.50;
        double kaktus = kaktusCount * 8;
        double profit = magnolii + zumbul + roses + kaktus - ((magnolii + zumbul + roses + kaktus) * 0.05);
        double diff = Math.abs(presentPrice - profit);

        if (presentPrice <= profit){
            System.out.printf("She is left with %.0f leva.", Math.floor(diff));
        }else{
            System.out.printf("She will have to borrow %.0f leva.", Math.ceil(diff));
        }
    }
}
