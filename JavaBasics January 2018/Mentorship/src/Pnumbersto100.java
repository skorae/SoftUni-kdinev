import java.util.Scanner;

public class Pnumbersto100 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int number = Integer.parseInt(scanner.nextLine());
        //String name = scanner.nextLine();


        if (0 > number || number > 100) {
            System.out.println("invalid number");
        } else if (9 < number && number <= 19) {
            switch (number) {
                case 11:
                    System.out.println("eleven");
                    break;
                case 12:
                    System.out.println("twelve");
                    break;
                case 13:
                    System.out.println("thirteen");
                    break;
                case 14:
                    System.out.println("fourteen");
                    break;
                case 15:
                    System.out.println("fifteen");
                    break;
                case 16:
                    System.out.println("sixteen");
                    break;
                case 17:
                    System.out.println("seventeen");
                    break;
                case 18:
                    System.out.println("eighteen");
                    break;
                case 19:
                    System.out.println("nineteen");
                    break;
            }
        } else if (0 < number && number < 10 || 19 < number && number < 100) {
            int once = number % 10;
            int tens = number / 10;
            String onesString = "";
            String tensString = "";

            switch (once) {
                case 1:
                    onesString = "one";
                    break;
                case 2:
                    onesString = "two";
                    break;
                case 3:
                    onesString = "three";
                    break;
                case 4:
                    onesString = "four";
                    break;
                case 5:
                    onesString = "five";
                    break;
                case 6:
                    onesString = "six";
                    break;
                case 7:
                    onesString = "seven";
                    break;
                case 8:
                    onesString = "eight";
                    break;
                case 9:
                    onesString = "nine";
                    break;
            }
            switch (tens) {
                case 2:
                    tensString = "twenty";
                    break;
                case 3:
                    tensString = "thirty";
                    break;
                case 4:
                    tensString = "forty";
                    break;
                case 5:
                    tensString = "fifty";
                    break;
                case 6:
                    tensString = "sixty";
                    break;
                case 7:
                    tensString = "seventy";
                    break;
                case 8:
                    tensString = "eighty";
                    break;
                case 9:
                    tensString = "ninety";
                    break;
            }
            if (once == 0) {
                System.out.println(tensString);
            } else {
               if (tens == 0) {
                   System.out.println(onesString);
               }else{
                   System.out.printf("%s %s", tensString, onesString);
               }
            }
        }if (number == 0){
            System.out.println("zero");
        }
        if (number == 10){
            System.out.printf("ten");
        }
        if (number == 100){
            System.out.println("one hundred");
        }
    }
}



                /// switch (name) {
                ///     case "Pesho":
                ///         System.out.println("one");
                ///         break;
                ///     case "Gosho":
                ///         System.out.println("two");
                ///         break;
                ///     case "Misho":
                ///         System.out.println("three");
                ///         break;
                ///     default:
                ///         System.out.println("Nobody");
                ///         break;
//           }
//       }
//   }

