import java.util.Scanner;

public class PTime15Minutes {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int hour = Integer.parseInt(scanner.nextLine());
        int minute = Integer.parseInt(scanner.nextLine());
        int addTime = 15;

        int newMinute = minute + addTime;
        int newHour = hour;

        if (newMinute > 59) {
            newHour = hour + 1;
            newMinute -= 60;

            if (newHour > 23) {
                newHour -= 24;
            }
        }

        if (newMinute < 10){
            System.out.printf(("%d:0%d"), newHour, newMinute);
        }else{
            System.out.printf(("%d:%d"), newHour, newMinute);
        }

    }
}
