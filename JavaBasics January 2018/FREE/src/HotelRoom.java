import java.util.Scanner;

public class HotelRoom {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String month = scanner.nextLine();
        int days = Integer.parseInt(scanner.nextLine());
        double studio = 0;
        double appartment = 0;



        if (month.equalsIgnoreCase("may") || month.equalsIgnoreCase("october")){
            if (days <= 7) {
                studio = days * 50;
                appartment = days * 65;
            }else if (days <= 14){
                studio = (days * 50) - ((days * 50) * 0.05);
                appartment = days * 65;
            }else{
                studio = (days * 50) - ((days * 50) * 0.3);
                appartment = (days * 65) - ((days * 65) * 0.1);
            }

        }else if (month.equalsIgnoreCase("June") || month.equalsIgnoreCase("september")){
            if (days <= 14) {
                studio = days * 75.20;
                appartment = days * 68.70;
            }else{
                studio = (days * 75.20) - ((days * 75.20) * 0.2);
                appartment = (days * 68.70) - ((days * 68.70) * 0.1);
            }
        }else if (month.equalsIgnoreCase("july") || month.equalsIgnoreCase("august")){
            if (days <= 14){
                studio = days * 76;
                appartment = days * 77;
            }else{
                studio = days * 76;
                appartment = (days * 77) - ((days * 77) * 0.1);
            }
        }
        System.out.printf("Apartment: %.2f lv.\n", appartment);
        System.out.printf("Studio: %.2f lv.", studio);
    }
}
