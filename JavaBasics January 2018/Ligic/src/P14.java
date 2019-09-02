import java.util.Scanner;

public class P14 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int hours = Integer.parseInt(scanner.nextLine());
        int minutes = Integer.parseInt(scanner.nextLine());
        int timeToAdd = 15;

       int newHours = hours;
       int newminutes = minutes + timeToAdd;

       if (newminutes >= 60) {
           newHours = hours + 1;
           newminutes -= 60;

           if (newHours > 23) {
               newHours -= 24;
           }
       }
        if (newminutes < 10){
            System.out.printf("%d:0%d", newHours, newminutes);
        }else{
            System.out.printf("%d:%d", newHours, newminutes);
        }
    }
}
