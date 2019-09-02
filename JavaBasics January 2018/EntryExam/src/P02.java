import java.util.Scanner;

public class P02 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int holeWight = Integer.parseInt(scanner.nextLine());
        int holeLenght = Integer.parseInt(scanner.nextLine());
        int paintingSide = Integer.parseInt(scanner.nextLine());
        int picCount = Integer.parseInt(scanner.nextLine());

        int sHole = holeLenght * holeWight;
        int sPainting = (paintingSide * paintingSide) * picCount;
        int diff = Math.abs(sHole - sPainting);

        if (sHole < sPainting ){
            System.out.printf("The pictures don't fit in the hole. ");
            System.out.printf("Picture area is %d bigger than hole area.", diff);
        }else{
            System.out.printf("The pictures fit in the hole. ");
            System.out.printf("Hole area is %d bigger than pictures area.", diff);
        }

    }
}
