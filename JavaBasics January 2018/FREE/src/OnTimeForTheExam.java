import java.util.Scanner;

public class OnTimeForTheExam {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int examHour = Integer.parseInt(scanner.nextLine());
        int examMinute = Integer.parseInt(scanner.nextLine());
        int arrivalHour = Integer.parseInt(scanner.nextLine());
        int arrivalMinute = Integer.parseInt(scanner.nextLine());

        int examTime = examHour * 60 + examMinute;
        int arrivalTime = arrivalHour * 60 + arrivalMinute;
        int earlyLate = examTime - arrivalTime;

        if (earlyLate > 0 && earlyLate <= 30) {
            System.out.printf("On time%n%d minutes before the start", earlyLate);
        } else if (earlyLate == 0) {
                System.out.printf("On time");
        } else if (earlyLate > 30 && earlyLate < 60) {
            System.out.printf("Early%n%d minutes before the start", earlyLate);
        }else if (earlyLate >= 60) {
                int hours = earlyLate / 60;
                int minutes = earlyLate % 60;
                if (minutes > 10) {
                    System.out.printf("Early%n%d:%d hours before the start", hours, minutes);
                }else if (minutes < 10) {
                    System.out.printf("Early%n%d:0%d hours before the start", hours, minutes);
                }
        } else if (earlyLate < 0) {
            earlyLate = arrivalTime - examTime;
            if (earlyLate < 60)
            System.out.printf("Late%n%d minutes after the start", earlyLate);
            if (earlyLate >= 60) {
                int hours = earlyLate / 60;
                int minutes = earlyLate % 60;
                if (minutes > 10) {
                    System.out.printf("Late%n%d:%d hours after the start", hours, minutes);
                }else if (minutes < 10) {
                    System.out.printf("Late%n%d:0%d hours after the start", hours, minutes);
                }
            }
        }
    }
}