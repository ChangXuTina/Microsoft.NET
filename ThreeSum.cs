public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> ans = new List<IList<int>>();
        Array.Sort(nums);
        int left, right;

        for(int i = 0; i < nums.Length - 2; i++) {
            while(i - 1 >= 0 && i < nums.Length && nums[i] == nums[i - 1]) i++;
            left = i + 1;
            right = nums.Length - 1;
            
            while(left < right && left < nums.Length && right >= 0) {
                int curSum = nums[i] + nums[left] + nums[right];
                if(curSum == 0) {
                    int[] curAns = {nums[i], nums[left++], nums[right--]};
                    ans.Add(curAns.ToList());
                    while(left < right && nums[left - 1] == nums[left]) left++;
                    while(left < right && nums[right] == nums[right + 1]) right--;
                } else if(curSum < 0) {
                    left++;
                } else{// curSum > target
                    right--;
                }                
            }
        }
        return ans;
    }
}