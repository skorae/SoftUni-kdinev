import java.util.Scanner;

public class P14 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int examHour = Integer.parseInt(scanner.nextLine());
        int examminutes = Integer.parseInt(scanner.nextLine());
        int arrivalHour = Integer.parseInt(scanner.nextLine());
        int arrivalMinute = Integer.parseInt(scanner.nextLine());

        int examInMinutes = examHour * 60 + examminutes;
        int arrivalInMinutes = arrivalHour * 60 + arrivalMinute;
        int minutes = Math.abs((arrivalInMinutes - examInMinutes) % 60);
        int hour = Math.abs((arrivalInMinutes - examInMinutes) / 60);

        if (arrivalInMinutes > examInMinutes) {
            System.out.println("Late");
            if (hour <= 0) {
                System.out.printf("%d minutes after the start", minutes);
            } else {
                if (minutes < 10) {
                    System.out.printf("%d:0%d hours after the start", hour, minutes);
                } else {
                    System.out.printf("%d:%d hours after the start", hour, minutes);
                }
            }
        } else if ((examInMinutes - arrivalInMinutes > 30)) {
            System.out.println("Early");
            if (hour <= 0) {
                System.out.printf("%d minutes before the start", minutes);
            } else {
                if (minutes < 10) {
                    System.out.printf("%d:0%d hours before the start", hour, minutes);
                } else {
                    System.out.printf("%d:%d hours before the start", hour, minutes);
                }

            }
        }else{
            System.out.println("On time");
            if (examInMinutes != arrivalInMinutes){
                System.out.printf("%d minutes before the start", minutes);
            }
        }
    }
}
