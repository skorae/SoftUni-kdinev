import java.util.Scanner;

public class EqualSums {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        String line = scan.nextLine();
        String[] arr = line.split("\\s+");
        int[] arr2 = new int[arr.length];
        for (int i = 0; i < arr.length; i++) {
            arr2[i] = Integer.parseInt(arr[i]);
        }
        boolean isFound = false;

        for (int currentElement = 0; currentElement < arr2.length; currentElement++)
        {
            int sumLeft = 0;
            int sumRight = 0;

            for (int i = currentElement + 1; i < arr2.length; i++)
            {
                sumRight += arr2[i];
            }
            for (int i = 0; i < currentElement; i++)
            {
                sumLeft += arr2[i];
            }

            if (sumRight == sumLeft)
            {
                System.out.print(currentElement);
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            System.out.print("no");
        }
    }
}