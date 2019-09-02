import java.util.Scanner;

public class CourierExpress {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double weight = Double.parseDouble(scanner.nextLine());
        String type = scanner.nextLine().toLowerCase();
        double distance = Double.parseDouble(scanner.nextLine());
        double fee = 0;
        double extra = 0;

        if (type.equals("standard")){
            if (weight < 1){
                fee = distance * 0.03;
            }else if (weight < 10){
                fee = distance *0.05;
            }else if (weight < 40) {
                fee = distance *0.10;
            }else if (weight < 90) {
                fee = distance *0.15;
            }else {
                fee = distance *0.20;
            }
            System.out.printf("The delivery of your shipment with weight of %.3f kg. would cost %.2f lv.", weight, fee);
        }else if (type.equals("express")){
            if (weight < 1){
                fee = distance * 0.03;
                extra = 0.80;
            }else if (weight < 10){
                fee = distance *0.05;
                extra = 0.40;
            }else if (weight < 40) {
                fee = distance *0.10;
                extra = 0.05;
            }else if (weight < 90) {
                fee = distance *0.15;
                 extra = 0.02;
            }else {
                fee = distance * 0.20;
                extra = 0.01;
            }
            double cost = fee + ((fee * extra) * weight);
            System.out.printf("The delivery of your shipment with weight of %.3f kg. would cost %.2f lv.", weight, cost);
        }
    }
}
